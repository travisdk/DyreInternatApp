using System.ComponentModel.DataAnnotations;
using DyreInternatApp.Domain.Models;

namespace DyreInternatApp.ViewModels
{
    public class SpeciesVM
    {
        public int SpeciesId { get; set; }

        [Required]
        [Display(Name="Dyreart")]
        [MaxLength(50)]
        public string SpeciesName { get; set;}

    }
}
