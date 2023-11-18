using DyreInternatApp.Models;
using DyreInternatApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DyreInternatApp.Controllers
{
    public class SpeciesController : Controller
    {
        private ISpeciesRepository _speciesRepository;  
        public SpeciesController(ISpeciesRepository speciesRepository)
        {
            _speciesRepository = speciesRepository;
        }
        public IActionResult Index()
        {
            var species = _speciesRepository.GetAll();
            return View(species);
        }

         
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SpeciesId, SpeciesName")]Species newSpecies) {
        
           if (ModelState.IsValid)
            {
                _speciesRepository.AddSpecies(newSpecies);
                 return RedirectToAction("Index");
            }

            return View(newSpecies);
        
        }
    }
}
