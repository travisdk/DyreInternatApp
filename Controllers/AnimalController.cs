using DyreInternatApp.SharedModels.Models;
using DyreInternatApp.BL.Services;
using DyreInternatApp.SharedViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DyreInternatApp.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService  animalService)
        {
            _animalService = animalService;
        }
        public async Task<IActionResult> Index()
        {
            var allAnimalsList = await _animalService.SimpleAnimalList();
            return View(allAnimalsList);
        }
    }
}
