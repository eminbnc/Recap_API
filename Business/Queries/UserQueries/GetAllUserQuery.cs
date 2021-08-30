using Core.Utilities.Results;
using Entities.DTO.Request.UserRequest;
using MediatR;
using System.Collections.Generic;

namespace Business.Queries.UserQueries
{
    public class GetAllUserQuery:IRequest<IDataResult<List<GetUsersResponse>>>
    {
    }
}
