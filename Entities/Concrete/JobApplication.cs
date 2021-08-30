using Core.Entities;

namespace Entities.Concrete
{
    public class JobApplication:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobPostingId { get; set; }
    }
}
