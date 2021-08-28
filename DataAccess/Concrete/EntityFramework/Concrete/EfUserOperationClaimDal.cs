using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfUserOperationClaimDal:EfEntityRepositoryBase<UserOperationClaim,RecapAPIContext>,IUserOperationClaimDal
    {
    }
}
