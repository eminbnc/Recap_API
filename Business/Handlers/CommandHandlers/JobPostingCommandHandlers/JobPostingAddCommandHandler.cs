using AutoMapper;
using Business.BusinessAuthAspects.Autofac;
using Business.Commands.JobPostingCommands;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO.Request.JobPostingRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.CommandHandlers.JobPostingCommandHandlers
{
    public class JobPostingAddCommandHandler: IRequestHandler<JobPostingAddCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IJobPostingDal _jobPostingDal;
        public JobPostingAddCommandHandler(IJobPostingDal jobPostingDal, IMapper mapper)
        {
            _jobPostingDal = jobPostingDal;
            _mapper = mapper;
        }
        [SecuredOperation("admin,company", Priority = 1)]
        public async Task<IResult> Handle(JobPostingAddCommand request, CancellationToken cancellationToken)
        {
            JobPosting newJobPosting = _mapper.Map<JobPosting>(request.JobPostingAddRequest);
            newJobPosting.Status = true;
            newJobPosting.StartingDate = DateTime.Now;
            newJobPosting.EndDate = DateTime.Now.AddDays(15);
            await _jobPostingDal.Add(newJobPosting);
            return new SuccessResult(Messages.JobPostingAddSuccessful);
        }
    }
}
