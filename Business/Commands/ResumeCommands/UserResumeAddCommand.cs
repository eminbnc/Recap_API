using Core.Utilities.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commands.ResumeCommands
{
    public class UserResumeAddCommand : IRequest<IResult>
    {
        public IFormFile ResumeFile { get; }
        public int UserId { get;  }
        public UserResumeAddCommand(IFormFile imageFile, int userId)
        {
            ResumeFile = imageFile;
            UserId = userId;
        }
    }
}
