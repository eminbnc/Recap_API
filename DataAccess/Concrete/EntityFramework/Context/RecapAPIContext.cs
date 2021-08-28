using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class RecapAPIContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9KV2AGP\SQLEXPRESS;Database=HRMSDB;Trusted_Connection=true");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<UserJobPosting> UserJobPostings { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
    }
}
