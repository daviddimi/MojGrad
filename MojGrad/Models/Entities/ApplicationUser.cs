using Microsoft.AspNetCore.Identity;

namespace MojGrad.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? ChangedByUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public int? MunicipalityId { get; set; }
        public Municipality? Municipality { get; set; }
        
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<ReportStatusHistory> StatusHistory { get; set; } = new List<ReportStatusHistory>();

    }
}
