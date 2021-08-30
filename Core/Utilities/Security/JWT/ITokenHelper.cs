using Core.Entities.ClaimInformation;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(InformationToAddedClaim user, List<OperationClaim> operationClaims);
    }
}
