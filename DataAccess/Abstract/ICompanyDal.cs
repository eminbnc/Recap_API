using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICompanyDal:IEntityRepository<Company>
    {
        Task<List<OperationClaim>> GetClaims(Company company);
    }
}
