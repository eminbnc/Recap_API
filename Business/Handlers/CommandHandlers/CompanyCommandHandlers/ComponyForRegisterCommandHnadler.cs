using AutoMapper;
using Business.Commands.CompanyCommands;
using Business.Constants;
using Business.Validation.FluentValidation.CompanyValidation;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.CompanyCommandHandlers
{
    public class ComponyForRegisterCommandHnadler : IRequestHandler<CompanyForRegisterCommand, IResult>
    {
        private readonly ICompanyDal _companyDal;
        private readonly ICompanyOperationClaimDal _companyOperationClaimDal;
        private readonly IMapper _mapper;
        public ComponyForRegisterCommandHnadler(ICompanyDal companyDal, ICompanyOperationClaimDal companyOperationClaimDal, IMapper mapper)
        {
            _companyDal = companyDal;
            _companyOperationClaimDal = companyOperationClaimDal;
            _mapper = mapper;
        }
        [TransactionScopeAspect(Priority = 2)]
        [ValidationAspect(typeof(CompanyRegisterValidator), Priority = 1)]
        public async Task<IResult> Handle(CompanyForRegisterCommand request, CancellationToken cancellationToken)
        {
            var checkIfEmail = await _companyDal.Get(p => p.Email == request._companyForRegisterRequest.Email);
            if (checkIfEmail != null) return new ErrorResult(Messages.EmailAlreadyExist);

            byte[] passwordHash, paswordSalt;
            HashingHelper.CreatePasswordHash(request._companyForRegisterRequest.Password,
                out passwordHash, out paswordSalt);
            var newCompany = _mapper.Map<Company>(request._companyForRegisterRequest);
            newCompany.Status = true;
            newCompany.PasswordHash = passwordHash;
            newCompany.PasswordSalt = paswordSalt;
            
            await _companyDal.Add(newCompany);
            var checkIfEmailForRegister = await _companyDal.Get(p => p.Email == request._companyForRegisterRequest.Email);
            await _companyOperationClaimDal.Add(new CompanyOperationClaim { OperationClaimId = 3, CompanyId = checkIfEmailForRegister.Id });
            return new SuccessResult(Messages.RegistrationIsSuccessful);
        }
    }
}
