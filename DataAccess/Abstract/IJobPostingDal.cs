using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IJobPostingDal:IEntityRepository<JobPosting>
    {
        Task<List<JobPosting>> PostingsIApplied(int id);
    }
}
