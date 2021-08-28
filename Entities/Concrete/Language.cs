using Core.Entities;

namespace Entities.Concrete
{
    public class Language:IEntity
    {
        public int Id { get; set; }
        public int ResumeId { get; set; }
        public string ProgramingLanguage { get; set; }
    }
}
