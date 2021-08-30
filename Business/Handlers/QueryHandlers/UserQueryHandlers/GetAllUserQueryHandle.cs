using AutoMapper;
using Business.BusinessAuthAspects.Autofac;
using Business.Constants;
using Business.Queries.UserQueries;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTO.Request.UserRequest;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.QueryHandlers.UserQueryHandlers
{
    public class GetAllUserQueryHandle : IRequestHandler<GetAllUserQuery, IDataResult<List<GetUsersResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;
        public GetAllUserQueryHandle(IMapper mapper, IUserDal userDal)
        {
            _mapper = mapper;
            _userDal = userDal;
        }

        [CacheAspect]
        [SecuredOperation("admin,editör,company",Priority =1)]
        public async Task<IDataResult<List<GetUsersResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var getAllUsers = await _userDal.GetAll(p => p.Visibility == true);
            if (getAllUsers.Count > 0) return new SuccessDataResult<List<GetUsersResponse>>(_mapper.Map<List<GetUsersResponse>>(getAllUsers), Messages.UserList);
            return new ErrorDataResult<List<GetUsersResponse>>(Messages.UserNotFound);
        }
    }
}
