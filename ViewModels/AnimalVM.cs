using DyreInternatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.ViewModels
{
    public class AnimalVM
    {
        public int AnimalId { get; set; }
        [Required]
        [Display(Name = "Navn")]
        public string AnimalName { get; set; }
        [Required]
        public int RaceId { get; set; }

        [Display(Name = "Pris DKK")]
        public decimal Price { get; set; }
        [Display(Name = "Vaccineret?")]
        public bool IsVaccinated { get; set; }
        [Display(Name = "TagKode")]
        public string? TagCode { get; set; }
        [Display(Name = "Fødselsdato")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Vægt KG")]
        public int Weight { get; set; }  // KG
        [Display(Name = "Beskrivelse")]
        public string? Notes { get; set; }

        [HiddenInput]
        public string? ImageFileName { get; set; }

        public Race? Race { get; set; }

        // non-model helpers
        public IEnumerable<SelectListItem>? RaceList { get; set; }

        public IFormFile? ImageFile { get; set; }

       
    }
}
