using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        [Required]
        [Display(Name ="Racenavn")]
        [StringLength(50)]
        public string RaceName { get; set; }
        public int SpeciesId { get; set; }

        [Display(Name = "Dyreart")]
        public Species Species { get; set; }

    }
}
