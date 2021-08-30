using Core.Entities;

namespace Entities.Concrete
{
    public class CompanyOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
