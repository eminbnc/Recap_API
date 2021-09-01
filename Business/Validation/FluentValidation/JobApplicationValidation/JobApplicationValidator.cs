using Business.Commands.JobApplicationCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation.JobApplicationValidation
{
    public class JobApplicationValidator : AbstractValidator<UserJobApplicationCommand>
    {
        public JobApplicationValidator()
        {
            RuleFor(p => p.UserJobApplicationRequest.UserId).NotEmpty();
            RuleFor(p => p.UserJobApplicationRequest.JobPostingId).NotEmpty();
        }
    }
}
