using BulkyBookWeb.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Seller:IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? username { get; set; }



    }
}
