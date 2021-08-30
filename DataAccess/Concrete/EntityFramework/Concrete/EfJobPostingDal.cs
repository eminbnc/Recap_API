using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfJobPostingDal : EfEntityRepositoryBase<JobPosting, RecapAPIContext>, IJobPostingDal
    {
        public async Task<List<JobPosting>> PostingsIApplied(int id)
        {
            await using (var context = new RecapAPIContext())
            {
                var result = from jobPosting in context.JobPostings
                             join jobApplication in context.JobApplications
                             on jobPosting.Id equals jobApplication.JobPostingId
                             where jobApplication.UserId == id
                             select new JobPosting
                             {
                                 Id=jobPosting.Id,
                                 CompanyId = jobPosting.CompanyId,
                                 Position = jobPosting.Position,
                                 JobDetail = jobPosting.JobDetail,
                                 Experience = jobPosting.Experience,
                                 Status = jobPosting.Status,
                                 StartingDate = jobPosting.StartingDate,
                                 EndDate = jobPosting.EndDate
                             };
                return result.ToList();
            }
        }
    }
}
