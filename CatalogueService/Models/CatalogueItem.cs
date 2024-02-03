namespace CatalogueService.Models
{
    public class CatalogueItem
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string Album { get; set; } = null!;
        public decimal Price { get; set; }
        public IEnumerable<string> Artists { get; set; } = null!;
        public IEnumerable<string> Genres { get; set; } = null!;
    }
}
