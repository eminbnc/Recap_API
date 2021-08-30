using Core.Utilities.Results;
using Entities.DTO.Request.JobPostingRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commands.JobPostingCommands
{
    public class JobPostingAddCommand: IRequest<IResult>
    {
        public JobPostingAddRequest JobPostingAddRequest { get; set; }
        public JobPostingAddCommand(JobPostingAddRequest jobPostingAddRequest)
        {
            JobPostingAddRequest = jobPostingAddRequest;
        }
    }
}
