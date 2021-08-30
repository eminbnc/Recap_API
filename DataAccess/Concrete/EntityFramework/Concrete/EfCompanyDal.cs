using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, RecapAPIContext>, ICompanyDal
    {
        public async Task<List<OperationClaim>> GetClaims(Company company)
        {
            await using (var context = new RecapAPIContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join CompanyOperationClaim in context.CompanyOperationClaims
                             on operationClaim.Id equals CompanyOperationClaim.OperationClaimId
                             where CompanyOperationClaim.CompanyId == company.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();

            }
        }
    }
}