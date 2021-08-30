using AutoMapper;
using Business.Commands.UserCommands;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Caching;
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
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        public UserForRegisterCommandHandler(IUserDal userDal,IUserOperationClaimDal userOperationClaimDal,IMapper mapper)
        {
            _mapper = mapper;
            _userDal = userDal;
            _userOperationClaimDal = userOperationClaimDal;
        }
        //[TransactionScopeAspect]
        [CacheRemoveAspect("GetAllUserQuery", Priority = 2)]
        [ValidationAspect(typeof(UserRegisterValidator), Priority = 1)]
        public async Task<IResult> Handle(UserForRegisterCommand request, CancellationToken cancellationToken)
        {
            var checkIfEmail = await _userDal.Get(p => p.Email == request._userRegisterRequest.Email);
            if (checkIfEmail != null) return new ErrorResult(Messages.EmailAlreadyExist);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request._userRegisterRequest.Password,
                out passwordHash, out passwordSalt);
            var newUser = _mapper.Map<User>(request._userRegisterRequest);
            newUser.Status = true;
            newUser.PasswordSalt = passwordSalt;
            newUser.PasswordHash = passwordHash;
            newUser.Visibility = true;
            await _userDal.Add(newUser);
            var checkIfEmailForRegister = await _userDal.Get(p => p.Email == request._userRegisterRequest.Email);
            await _userOperationClaimDal.Add(new UserOperationClaim { OperationClaimId = 3, UserId = checkIfEmailForRegister.Id });
            return new SuccessResult(Messages.RegistrationIsSuccessful);
        }
    }
}
