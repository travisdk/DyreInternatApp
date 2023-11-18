using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required]
        public string AnimalName { get; set;}
        [Required]
        public int RaceId { get; set; } 
        public decimal Price { get; set;}   
        public bool IsVaccinated { get; set;}   
        public string? TagCode { get; set;} 
        public DateTime? DateOfBirth { get; set;}
        [Required]
        public int Weight { get; set;}  // KG
        public string? Notes { get; set;}   
        public Race Race { get; set;}

    }
}
