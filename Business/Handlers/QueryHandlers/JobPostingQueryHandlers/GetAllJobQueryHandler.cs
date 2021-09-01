using Business.Constants;
using Business.Queries.JobPostingQueris;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQuery, IDataResult<List<JobPostingResponse>>>
    {
        private readonly IJobPostingDal _jobPostingDal;
        public GetAllJobQueryHandler(IJobPostingDal jobPostingDal)
        {
            _jobPostingDal = jobPostingDal;
        }
        public async Task<IDataResult<List<JobPostingResponse>>> Handle(GetAllJobQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobPostingDal.GetAllJob();
            return new SuccessDataResult<List<JobPostingResponse>>(result, Messages.PostingsIAppliedSuccesful);
        }
    }
}
