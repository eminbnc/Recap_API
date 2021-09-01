using Core.Utilities.Results;
using Entities.Concrete;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.ResumeQueries
{
    public class GetResumeByUserIdQuery : IRequest<IDataResult<List<Resume>>>
    {
        public int UserId { get; set; }
        public GetResumeByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
