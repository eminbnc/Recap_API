using System;

namespace Entities.DTO.Response.JobPostingResponse
{
    public class JobPostingResponse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string JobDetail { get; set; }
        public string Experience { get; set; }
        public bool Status { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Language { get; set; }
        public int UserId { get; set; }
    }
}
