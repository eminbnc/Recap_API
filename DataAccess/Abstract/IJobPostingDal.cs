using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO.Response.JobPostingResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IJobPostingDal:IEntityRepository<JobPosting>
    {
        Task<List<JobPostingResponse>> PostingsIApplied(int id);
        Task<List<JobPostingResponse>> GetAllJob();
    }
}
