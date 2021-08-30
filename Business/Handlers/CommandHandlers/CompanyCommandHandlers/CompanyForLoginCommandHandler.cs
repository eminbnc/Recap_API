using AutoMapper;
using Business.Commands.CompanyCommands;
using Business.Constants;
using Business.Validation.FluentValidation.CompanyValidation;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Entities.ClaimInformation;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.CompanyCommandHandlers
{
    public class CompanyForLoginCommandHandler : IRequestHandler<CompanyForLoginCommand, IDataResult<AccessToken>>
    {
        private readonly ICompanyDal _companyDal;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        public CompanyForLoginCommandHandler(ICompanyDal companyDal, ITokenHelper tokenHelper,IMapper mapper)
        {
            _companyDal = companyDal;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(CompanyLoginValidator), Priority = 1)]
        public async Task<IDataResult<AccessToken>> Handle(CompanyForLoginCommand request, CancellationToken cancellationToken)
        {
            var companyToCheck = await _companyDal .Get(p => p.Email == request._companyForLoginRequest.Email); 
            if (companyToCheck == null) return new ErrorDataResult<AccessToken>(Messages.LoginFailed);

            if (!HashingHelper.VerifyPasswordHash(request._companyForLoginRequest.
                Password, companyToCheck.PasswordHash, companyToCheck.PasswordSalt))
                return new ErrorDataResult<AccessToken>(Messages.LoginFailed);

            var claims = await _companyDal.GetClaims(companyToCheck);
            var accessToken = _tokenHelper.CreateToken(_mapper.Map<InformationToAddedClaim>(companyToCheck), claims);
            return new SuccessLoginDataResult<AccessToken>(accessToken, Messages.LoginSuccessful, companyToCheck.Id, claims[0].Name);
        }
    }
}
