using Core.Utilities.Results;
using Entities.DTO.Response.JobPostingResponse;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.JobPostingQueris
{
    public class PostingsIAppliedQuery : IRequest<IDataResult<List<JobPostingResponse>>>
    {
        public int Id { get; set; }
        public PostingsIAppliedQuery(int id)
        {
            Id = id;
        }
    }
}
