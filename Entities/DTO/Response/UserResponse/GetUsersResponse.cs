using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request.UserRequest
{
    public class GetUsersResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string ProfilPhotoUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public string SummaryInformation { get; set; }
        public string Adress { get; set; }
    }
}
