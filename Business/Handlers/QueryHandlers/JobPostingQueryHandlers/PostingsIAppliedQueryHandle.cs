﻿using Business.BusinessAuthAspects.Autofac;
using Business.Constants;
using Business.Queries.JobPostingQueris;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO.Response.JobPostingResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.JobPostingQueryHandlers
{
    public class PostingsIAppliedQueryHandle : IRequestHandler<PostingsIAppliedQuery, IDataResult<List<JobPostingResponse>>>
    {
        private readonly IJobPostingDal _jobPostingDal;
        public PostingsIAppliedQueryHandle(IJobPostingDal jobPostingDal)
        {
            _jobPostingDal = jobPostingDal;
        }
        [SecuredOperation("admin,editör,developer", Priority = 1)]
        public async Task<IDataResult<List<JobPostingResponse>>> Handle(PostingsIAppliedQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobPostingDal.PostingsIApplied(request.Id);
            return new SuccessDataResult<List<JobPostingResponse>>(result, Messages.PostingsIAppliedSuccesful);
        }
    }
}
