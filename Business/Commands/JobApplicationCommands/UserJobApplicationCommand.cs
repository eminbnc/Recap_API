using Core.Utilities.Results;
using Entities.DTO.Request.JobApplicationRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commands.JobApplicationCommands
{
    public class UserJobApplicationCommand:IRequest<IResult>
    {
        public UserJobApplicationRequest UserJobApplicationRequest { get; set; }
        public UserJobApplicationCommand(UserJobApplicationRequest userJobApplicationRequest)
        {
            UserJobApplicationRequest = userJobApplicationRequest;
        }
    }
}
