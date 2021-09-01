using Business.Constants;
using Business.Queries.ResumeQueries;
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

namespace Business.Handlers.QueryHandlers.ResumeQueryHandlers
{
    public class GetResumeByUserIdQueryHandler : IRequestHandler<GetResumeByUserIdQuery, IDataResult<List<Resume>>>
    {
        private readonly IResumeDal _resumeDal;

        public GetResumeByUserIdQueryHandler(IResumeDal resumeDal)
        {
            _resumeDal = resumeDal;
        }

        public async Task<IDataResult<List<Resume>>> Handle(GetResumeByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _resumeDal.GetAll(p => p.UserId == request.UserId);
            return new SuccessDataResult<List<Resume>>(result, Messages.GetResumeSuccesful);
        }
    }
}
