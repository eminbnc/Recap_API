using Core.Entities;

namespace Entities.Concrete
{
    public class Resume:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
