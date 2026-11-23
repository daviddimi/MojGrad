namespace MojGrad.Models.Entities
{
    public class Municipality : BaseEntity
    {
        public string? Name { get; set; } 

        // Navigation properties
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

    }
}
