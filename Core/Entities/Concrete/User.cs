using System;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public string ProfilPhotoUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public string SummaryInformation { get; set; }
        public string Adress { get; set; }
        public bool Visibility { get; set; }
    }
}
