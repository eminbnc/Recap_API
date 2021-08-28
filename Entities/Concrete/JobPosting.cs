using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class JobPosting:IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Position { get; set; }
        public string JobDetail { get; set; }
        public string Experience { get; set; }
        public bool Status { get; set; }
        public DateTime EndDate { get; set; }
    }
}
