using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfSchoolDal: EfEntityRepositoryBase<School, RecapAPIContext>, ISchoolDal
    {
    }
}
