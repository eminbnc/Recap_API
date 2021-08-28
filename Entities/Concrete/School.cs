using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class School:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolCity { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Department { get; set; }
    }
}
