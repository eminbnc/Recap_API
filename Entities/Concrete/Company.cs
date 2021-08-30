using Core.Entities;

namespace Entities.Concrete
{
    public class Company:IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public string ProfilPhotoUrl { get; set; }
        public string CompanyUrl { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string TaxAdministratationCity { get; set; }
        public string TaxAdministratationDistrict { get; set; }
    }
}
