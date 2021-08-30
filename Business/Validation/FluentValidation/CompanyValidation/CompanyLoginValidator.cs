using Business.Commands.CompanyCommands;
using FluentValidation;

namespace Business.Validation.FluentValidation.CompanyValidation
{
    public class CompanyLoginValidator : AbstractValidator<CompanyForLoginCommand>
    {
        public CompanyLoginValidator()
        {
            RuleFor(p => p._companyForLoginRequest.Email).NotEmpty().EmailAddress();
            RuleFor(p => p._companyForLoginRequest.Password).Length(6, 20).WithMessage("Parola alanı 6-20 karakter aralığında olmalıdır! ");
        }
    }
}
