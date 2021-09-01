using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Entities.DTO.Response.JobPostingResponse;
using System;

namespace DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfJobPostingDal : EfEntityRepositoryBase<JobPosting, RecapAPIContext>, IJobPostingDal
    {
        public async Task<List<JobPostingResponse>> GetAllJob()
        {
            await using (var context = new RecapAPIContext())
            {
                var result = from company in context.Companies
                             join jobPosting in context.JobPostings
                             on company.Id equals jobPosting.CompanyId
                             where jobPosting.EndDate>=DateTime.Now
                             join jobApplication in context.JobApplications
                             on jobPosting.Id equals jobApplication.JobPostingId
                             select new JobPostingResponse
                             {
                                 Id = jobPosting.Id,
                                 CompanyName = company.CompanyName,
                                 CompanyId = jobPosting.CompanyId,
                                 UserId=jobApplication.UserId,
                                 Position = jobPosting.Position,
                                 JobDetail = jobPosting.JobDetail,
                                 Experience = jobPosting.Experience,
                                 Status = jobPosting.Status,
                                 StartingDate = jobPosting.StartingDate,
                                 EndDate = jobPosting.EndDate,


                                 Language = jobPosting.Language
                             };
                return result.ToList();
            }
        }

        public async Task<List<JobPostingResponse>> PostingsIApplied(int id)
        {
            await using (var context = new RecapAPIContext())
            {
                var result = from jobApplication in context.JobApplications
                             join jobPosting in context.JobPostings
                             on jobApplication.JobPostingId equals jobPosting.Id
                             join company in context.Companies
                             on jobPosting.CompanyId equals company.Id

                             select new JobPostingResponse
                             {
                                 Id = jobPosting.Id,
                                 CompanyName = company.CompanyName,
                                 CompanyId = jobPosting.CompanyId,
                                 Position = jobPosting.Position,
                                 JobDetail = jobPosting.JobDetail,
                                 Experience = jobPosting.Experience,
                                 Status = jobPosting.Status,
                                 StartingDate = jobPosting.StartingDate,
                                 EndDate = jobPosting.EndDate,
                                 Language = jobPosting.Language
                             };
                return result.ToList();
            }
        }
    }
}
