using BulkyBookWeb.Models.Abstract;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Ürün İsmi")]
        public string? Name { get; set; }
  
        public int Price { get; set; }
      
        public string? Description { get; set; }
      
        public int SellerId { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
