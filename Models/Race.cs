using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Race
    {
        public int RaceId { get; set; }

        [MaxLength(50)]
        [Display(Name ="RaceNavn")]
        public string RaceName { get; set; }
        public int SpeciesId { get; set; }
        public Species Species { get; set; }

    }
}
