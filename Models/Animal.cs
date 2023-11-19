using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        public string AnimalName { get; set;}
   
        public int RaceId { get; set; }
    
        public decimal Price { get; set;}

        public bool IsVaccinated { get; set;}
        
   
        public string? TagCode { get; set;}
 
        public DateTime? DateOfBirth { get; set;}

        public int Weight { get; set;}  // KG
  
        public string? Notes { get; set;}   

        public Race Race { get; set;}

    }
}
