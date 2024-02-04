namespace CartService.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public decimal Discount { get; set; }
    }
}
