using AutoMapper;
using Business.BusinessAuthAspects.Autofac;
using Business.Commands.JobApplicationCommands;
using Business.Constants;
using Business.Validation.FluentValidation.JobApplicationValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.JobApplicationCommandHandlers
{
    public class UserJobApplicationCommandHandler : IRequestHandler<UserJobApplicationCommand, IResult>
    {
        private readonly IJobApplicationDal _jobApplicationDal;
        private readonly IMapper _mapper;
        public UserJobApplicationCommandHandler(IJobApplicationDal jobApplicationDal, IMapper mapper)
        {
            _jobApplicationDal = jobApplicationDal;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(JobApplicationValidator))]
        [SecuredOperation("developer")]
        public async Task<IResult> Handle(UserJobApplicationCommand request, CancellationToken cancellationToken)
        {
            await _jobApplicationDal.Add(_mapper.Map<JobApplication>(request.UserJobApplicationRequest));
            return new SuccessResult(Messages.UserJobAppApplicationSuccesful);
        }
    }
}
