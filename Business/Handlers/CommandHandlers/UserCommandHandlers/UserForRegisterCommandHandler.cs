using Business.Commands.UserCommands;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.UserCommandHandler
{
    public class UserForRegisterCommandHandler : IRequestHandler<UserForRegisterCommand, IResult>
    {
        IUserDal _userDal;
        IUserOperationClaimDal _userOperationClaimDal;
        public UserForRegisterCommandHandler(IUserDal userDal,IUserOperationClaimDal userOperationClaimDal)
        {
            _userDal = userDal;
            _userOperationClaimDal = userOperationClaimDal;
        }
        [TransactionScopeAspect(Priority =2)]
        [ValidationAspect(typeof(UserRegisterValidator), Priority = 1)]
        public async Task<IResult> Handle(UserForRegisterCommand request, CancellationToken cancellationToken)
        {
            var checkIfEmail = await _userDal.Get(p => p.Email == request._userRegisterRequest.Email);
            if (checkIfEmail != null) return new ErrorResult(Messages.EmailAlreadyExist);

            byte[] passwordHash, paswordSalt;
            HashingHelper.CreatePasswordHash(request._userRegisterRequest.Password,
                out passwordHash, out paswordSalt);
            var newUser = new User
            {
                Email = request._userRegisterRequest.Email,
                Telephone = request._userRegisterRequest.Telephone,
                FirstName = request._userRegisterRequest.FirstName,
                LastName = request._userRegisterRequest.LastName,
                Visibility = request._userRegisterRequest.Visibility,
                BirthDate = request._userRegisterRequest.BirthDate,
                Adress = request._userRegisterRequest.Adress,
                ProfilPhotoUrl = request._userRegisterRequest.ProfilPhotoUrl,
                SummaryInformation = request._userRegisterRequest.SummaryInformation,
                Status=true,
                PasswordHash = passwordHash,
                PasswordSalt = paswordSalt
            };
            await _userDal.Add(newUser);
            var checkIfEmailForRegister = await _userDal.Get(p => p.Email == request._userRegisterRequest.Email);
            await _userOperationClaimDal.Add(new UserOperationClaim { OperationClaimId = 66, UserId = checkIfEmailForRegister.Id });
            return new SuccessResult(Messages.RegistrationIsSuccessful);
        }
    }
}
