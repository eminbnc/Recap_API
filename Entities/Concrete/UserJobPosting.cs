using Core.Entities;

namespace Entities.Concrete
{
    public class UserJobPosting:IEntity
    {
        public int UserId { get; set; }
        public int JobPostingId { get; set; }
    }
}
