using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(20)]
        public string PostalCode { get; set; }
        [MaxLength(20)]

        public string Phone { get; set; }       

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
