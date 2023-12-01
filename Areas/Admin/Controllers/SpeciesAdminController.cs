
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using DyreInternatApp.ViewModels;
using DyreInternatApp.BL.Services;
using AutoMapper;
using DyreInternatApp.Domain.Models;


namespace DyreInternatApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize]
    public class SpeciesAdminController : Controller
    {
        private readonly ISpeciesService _speciesService;
        private readonly IMapper _mapper;

        public SpeciesAdminController(ISpeciesService speciesService, IMapper mapper)
        {
            _speciesService = speciesService;
            _mapper = mapper;
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
                var newSpecies = _mapper.Map<Species>(newSpeciesVM);
                await _speciesService.AddSpecies(newSpecies);
                return RedirectToAction("Index");
            }

            return View(newSpeciesVM);

        }
    }
}
