using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        [Required]
        public string CustomerId { get; set; } 
        public List<Animal> Animals { get; set; } = new List<Animal>();

        [Required]
        public DateTime OrderDate { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
