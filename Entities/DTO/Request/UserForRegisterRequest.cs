using System;

namespace Entities.DTO.Request
{
    public class UserForRegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string ProfilPhotoUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public string SummaryInformation { get; set; }
        public string Adress { get; set; }
        public bool Visibility { get; set; }
    }
}
