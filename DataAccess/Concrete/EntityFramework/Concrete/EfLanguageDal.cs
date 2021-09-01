using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfLanguageDal: EfEntityRepositoryBase<Language, RecapAPIContext>, ILanguageDal
    {
    }
}
