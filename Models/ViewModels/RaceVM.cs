using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DyreInternatApp.Models.ViewModels
{
    public class RaceVM
    {
        public int RaceId { get; set; }
        public string RaceName { get; set; }    
        public int SpeciesId { get; set; }


    }
}
