namespace MojGrad.Models.Entities
{
    public class Report : BaseEntity
    {
        public string? Title { get; set; } 
        public string? Description { get; set; } 
        /// <summary>
        /// Gets or sets the type of the report.
        /// </summary>
        /// <value>
        /// public ReportType Type { get; set; } = ReportType.Problem;
        /// public enum ReportType { Problem, Praise }
        ///</value>
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Navigation properties
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; } = null!;

        public ReportStatus Status { get; set; } = ReportStatus.Submitted;

        public string? ImagePath { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;


        public ICollection<ReportStatusHistory> StatusHistory { get; set; } = new List<ReportStatusHistory>();
    }
    public enum ReportStatus { Submitted, InProgress, Resolved, Rejected }
}
