namespace Entities.DTO.Response.CompanyResponse
{
    public class GetCompaniesResponse
    {
        public int Id { get; set; }
        public string ComponyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string ProfilPhotoUrl { get; set; }
        public string CompanyUrl { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string TaxAdministratationCity { get; set; }
        public string TaxAdministratationDistrict { get; set; }
    }
}
