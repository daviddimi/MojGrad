using MojGrad.Models.Enums;

namespace MojGrad.Models.Entities
{
    public class Report : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ReportType Type { get; set; } = ReportType.Problem;

        // Navigation properties
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; } = null!;
        public ReportStatus Status { get; set; } = ReportStatus.Submitted;

        public string ImagePath { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;


        public ICollection<ReportStatusHistory> StatusHistory { get; set; } = new List<ReportStatusHistory>();
    }
    public enum ReportStatus { Submitted, InProgress, Resolved, Rejected }
}
