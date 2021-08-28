using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WorkExperience:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string CompanySector { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public string WorkingPozition { get; set; }
        public string BusinessArea { get; set; }
    }
}
