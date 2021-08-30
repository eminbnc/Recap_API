using Business.Commands.UserCommands;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class UserRegisterValidator:AbstractValidator<UserForRegisterCommand>
    {
        public UserRegisterValidator()
        {
            RuleFor(p => p._userRegisterRequest.Email).NotEmpty().EmailAddress();
            RuleFor(p => p._userRegisterRequest.FirstName).Length(3,50);
            RuleFor(p => p._userRegisterRequest.LastName).Length(2,50);
            RuleFor(p => p._userRegisterRequest.Password).Length(6, 20);
            RuleFor(p => p._userRegisterRequest.Adress).NotEmpty();
            RuleFor(p => p._userRegisterRequest.BirthDate).NotEmpty();
            
        }
    }
}
