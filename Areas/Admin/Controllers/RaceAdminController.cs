using AutoMapper;
using DyreInternatApp.BL.Services;
using DyreInternatApp.Domain.Models;
using DyreInternatApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace DyreInternatApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RaceAdminController : Controller
    {
        private IRaceService _raceService;
        private readonly ISpeciesService _speciesService;
        private readonly IMapper _mapper;

        public RaceAdminController(IRaceService raceService, ISpeciesService speciesService, IMapper mapper)
        {
            _raceService = raceService;
            _speciesService = speciesService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var races = await _raceService.GetAllRaces();
            return View(races);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RaceId, RaceName, SpeciesId")] RaceVM newRaceVM)
        {

            if (ModelState.IsValid)
            {
                var newRace = _mapper.Map<Race>(newRaceVM);
                await _raceService.AddRace(newRace);
                return RedirectToAction("Index");
            }
            // REFAC
            var selList = new SelectList(await _speciesService.GetAllSpecies(), "SpeciesId", "SpeciesName", newRaceVM.SpeciesId);
            newRaceVM.SpeciesList = selList;
            return View(newRaceVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var allRaces = await _raceService.GetAllRaces();
            if (id == null || allRaces.Any() == false)
            {
                return NotFound();
            }

            var race = await _raceService.GetRaceById(id);
            var raceVM = _mapper.Map<RaceVM>(race); 
            if (race  == null)
            {
                return NotFound();
            }
            // REFAC
            var selList = new SelectList(await _speciesService.GetAllSpecies(), "SpeciesId", "SpeciesName");
            raceVM.SpeciesList = selList;
            return View(raceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("RaceId, RaceName, SpeciesId")] RaceVM raceVM)
        {

            if (ModelState.IsValid)
            {
                var race = _mapper.Map<Race>(raceVM);
                await _raceService.UpdateRace(race);
                return RedirectToAction("Index");
            }

            // REFAC
            var selList = new SelectList(await _speciesService.GetAllSpecies(), "SpeciesId", "SpeciesName", raceVM.SpeciesId);
            raceVM.SpeciesList = selList;
            return View(raceVM);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            var race = _raceService.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }
            var raceVM = _mapper.Map<RaceVM>(race);
            return View(raceVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _raceService.RemoveRaceById(id);
            return RedirectToAction(nameof(Index));
        }
    }


}