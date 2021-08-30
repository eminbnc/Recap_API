using Core.Utilities.Results;
using Entities.DTO.Request.CompanyRequest;
using MediatR;

namespace Business.Commands.CompanyCommands
{
    public class CompanyForRegisterCommand: IRequest<IResult>
    {
        public CompanyForRegisterRequest _companyForRegisterRequest { get; set; }
        public CompanyForRegisterCommand(CompanyForRegisterRequest companyForRegisterRequest)
        {
            _companyForRegisterRequest = companyForRegisterRequest;
        }
    }
}
