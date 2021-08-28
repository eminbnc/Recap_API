﻿using Business.Commands.UserCommands;
using Business.Constants;
using Business.Validation.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace Business.Handlers.CommandHandlers.UserCommandHandler
{
    public class UserForLoginCommandHandler : IRequestHandler<UserForLoginCommand, IDataResult<AccessToken>>
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;
        private ICacheManager _cacheManager;
        public UserForLoginCommandHandler(IUserDal userDal, ITokenHelper tokenHelper, ICacheManager cacheManager)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _cacheManager = cacheManager;
        }

        [ValidationAspect(typeof(UserLoginValidator), Priority = 1)]
        public async Task<IDataResult<AccessToken>> Handle(UserForLoginCommand request, CancellationToken cancellationToken)
        {
            var userToCheck = await _userDal.Get(p => p.Email == request._userForLoginRequest.Email);
            if (userToCheck == null) return new ErrorDataResult<AccessToken>(Messages.LoginFailed);

            if (!HashingHelper.VerifyPasswordHash(request._userForLoginRequest.
                Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorDataResult<AccessToken>(Messages.LoginFailed);

            var claims = await _userDal.GetClaims(userToCheck);
            var accessToken = _tokenHelper.CreateToken(userToCheck, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.LoginSuccessful);
        }
    }
}

