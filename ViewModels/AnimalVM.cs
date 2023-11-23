using DyreInternatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.ViewModels
{
    public class AnimalVM
    {
        public int AnimalId { get; set; }

        [Display(Name = "Navn")]
        [Required(ErrorMessage ="Dyrets navn er påkrævet")]
        public string AnimalName { get; set; }
        [Required]
        public int RaceId { get; set; }
        [Required(ErrorMessage = "Dyrets salgspris er påkrævet")]
        [Display(Name = "Pris DKK")]
        public decimal Price { get; set; }

        [UIHint("JaNej")]
        [Display(Name = "Vaccineret?")]
        public bool IsVaccinated { get; set; }
        [Display(Name = "TagKode")]
        public string? TagCode { get; set; }
        [Display(Name = "Fødselsdato")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Dyrets vægt i KG er påkrævet")]

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
