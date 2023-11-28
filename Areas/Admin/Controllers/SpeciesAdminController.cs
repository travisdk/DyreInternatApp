using DyreInternatApp.SharedModels.Models;
using DyreInternatApp.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DyreInternatApp.BL.Services;

namespace DyreInternatApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class SpeciesAdminController : Controller
    {
        private ISpeciesService _speciesService;
        public SpeciesAdminController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }
        public async Task<IActionResult> Index()
        {
            var species = await _speciesService.GetAllSpecies();
            return View(species);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpeciesId, SpeciesName")] SpeciesVM newSpeciesVM)
        {

            if (ModelState.IsValid)
            {
                await _speciesService.AddSpecies(newSpeciesVM);
                return RedirectToAction("Index");
            }

            return View(newSpeciesVM);

        }
    }
}
