using System.ComponentModel.DataAnnotations;

namespace DyreInternatApp.Models
{
    public class Species
    {
        public int SpeciesId { get; set; }

        [Required]
        [Display(Name="Dyreart")]
        [StringLength(50)]
        public string SpeciesName { get; set;}

    }
}
