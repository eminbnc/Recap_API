using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request.JobPostingRequest
{
    public class JobPostingAddRequest
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Position { get; set; }
        public string JobDetail { get; set; }
        public string Experience { get; set; }
    }
}
