namespace MojGrad.Models.Entities
{
    public class ReportStatusHistory : BaseEntity
    {
        public ReportStatus OldStatus { get; set; }
        public ReportStatus NewStatus { get; set; }
        public string? Comment { get; set; } 

        //Navigation properties
        public int? ReportId { get; set; }
        public Report Report { get; set; } = null!;

        public string? ChangedByUserId { get; set; }
        public ApplicationUser ChangedByUser { get; set; } = null!;

    }
}
