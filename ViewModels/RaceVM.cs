using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.ViewModels
{
    public class RaceVM
    {
        public int RaceId { get; set; }

        [Display(Name = "RaceNavn")]
        public string RaceName { get; set; }
        public int SpeciesId { get; set; }

        public IEnumerable<SelectListItem>? SpeciesList { get; set; }

    }
}
