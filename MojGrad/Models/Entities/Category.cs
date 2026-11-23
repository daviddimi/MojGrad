namespace MojGrad.Models.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }

        // Navigation properties
        public ICollection<Report> Reports { get; set; } = new List<Report>();

    }
}

