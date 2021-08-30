using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.JobPostingQueris
{
    public class PostingsIAppliedQuery : IRequest<IDataResult<List<JobPosting>>>
    {
        public int Id { get; set; }
        public PostingsIAppliedQuery(int id)
        {
            Id = id;
        }
    }
}
