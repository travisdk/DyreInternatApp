using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [MaxLength(50)]
        public string AnimalName { get; set;}

        public int RaceId { get; set; }


        [Precision(8,2)]
        public decimal Price { get; set;}

        [UIHint("JaNej")]
        public bool IsVaccinated { get; set;}
        
        [MaxLength(20)]        
        public string? TagCode { get; set;}
 
        public DateTime? DateOfBirth { get; set;}

        public int Weight { get; set;}  // KG

        [MaxLength(3000)]
        public string? Notes { get; set;}
      
        [HiddenInput]
        public string? ImageFileName { get; set; }

        public Race Race { get; set;}

    }
}
