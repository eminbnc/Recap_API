using Business.Commands.CompanyCommands;
using FluentValidation;

namespace Business.Validation.FluentValidation.CompanyValidation
{
    public class CompanyRegisterValidator:AbstractValidator<CompanyForRegisterCommand>
    {
        public CompanyRegisterValidator()
        {
            RuleFor(p => p._companyForRegisterRequest.Email).NotEmpty().EmailAddress();
            RuleFor(p => p._companyForRegisterRequest.FirstName).Length(3, 50);
            RuleFor(p => p._companyForRegisterRequest.CompanyName).Length(3, 150);
            RuleFor(p => p._companyForRegisterRequest.LastName).Length(2, 50);
            RuleFor(p => p._companyForRegisterRequest.Password).Length(6, 20);
            RuleFor(p => p._companyForRegisterRequest.City).NotEmpty();
            RuleFor(p => p._companyForRegisterRequest.TaxAdministratationCity).NotEmpty();
            RuleFor(p => p._companyForRegisterRequest.TaxAdministratationDistrict).NotEmpty();
        }
    }
}
