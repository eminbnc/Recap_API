using Core.Utilities.Results;
using Entities.DTO.Request;
using MediatR;

namespace Business.Commands.UserCommands
{
    public class UserForRegisterCommand : IRequest<IResult>
    {
        public UserForRegisterRequest _userRegisterRequest { get; set; }

        public UserForRegisterCommand(UserForRegisterRequest userRegisterRequest)
        {
            _userRegisterRequest = userRegisterRequest;
        }
    }
}
