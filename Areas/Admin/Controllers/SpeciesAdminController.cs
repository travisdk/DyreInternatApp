using DyreInternatApp.Models;
using DyreInternatApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DyreInternatApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class SpeciesAdminController : Controller
    {
        private ISpeciesRepository _speciesRepository;
        public SpeciesAdminController(ISpeciesRepository speciesRepository)
        {
            _speciesRepository = speciesRepository;
        }
        public async Task< IActionResult> Index()
        {
            var species = await _speciesRepository.GetAll();
            return View(species);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpeciesId, SpeciesName")] Species newSpecies)
        {

            if (ModelState.IsValid)
            {
                await _speciesRepository.AddSpecies(newSpecies);
                return RedirectToAction("Index");
            }

            return View(newSpecies);

        }
    }
}
