using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTO.Request.CompanyRequest;
using MediatR;

namespace Business.Commands.CompanyCommands
{
    public class CompanyForLoginCommand:IRequest<IDataResult<AccessToken>>
    {
        public CompanyForLoginRequest _companyForLoginRequest{ get; set; }
        public CompanyForLoginCommand(CompanyForLoginRequest  companyForLoginRequest)
        {
            _companyForLoginRequest = companyForLoginRequest;
        }
    }
}
