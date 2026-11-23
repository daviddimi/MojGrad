namespace MojGrad.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Report> Reports { get; set; } = new List<Report>();

    }
}

