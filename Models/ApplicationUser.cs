using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(30)]
        public string Address { get; set; }
        [MaxLength(20)]
        public string City { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
      


        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
