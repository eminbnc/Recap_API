using Core.Utilities.Results;
using Entities.DTO.Response.JobPostingResponse;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.JobPostingQueris
{
    public class GetAllJobQuery : IRequest<IDataResult<List<JobPostingResponse>>>
    {

    }
}
