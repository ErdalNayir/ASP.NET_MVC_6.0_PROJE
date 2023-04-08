using BulkyBookWeb.Models.Abstract;

namespace BulkyBookWeb.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public int SellerId { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
