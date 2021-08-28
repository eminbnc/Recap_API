using Business.Commands.UserCommands;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class UserLoginValidator:AbstractValidator<UserForLoginCommand>
    {
        public UserLoginValidator()
        {
            RuleFor(p => p._userForLoginRequest.Email).NotEmpty().EmailAddress();
            RuleFor(p => p._userForLoginRequest.Password).Length(6, 20);
        }
    }
}
