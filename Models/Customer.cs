using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }       

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
