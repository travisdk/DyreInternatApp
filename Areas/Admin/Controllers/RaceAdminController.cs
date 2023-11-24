using AutoMapper;
using DyreInternatApp.Models;
using DyreInternatApp.Repositories;
using DyreInternatApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DyreInternatApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RaceAdminController : Controller
    {
        private IRaceRepository _raceRepository;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly IMapper _mapper;

        public RaceAdminController(IRaceRepository raceRepository, ISpeciesRepository speciesRepository, IMapper mapper)
        {
            _raceRepository = raceRepository;
            _speciesRepository = speciesRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var races = _raceRepository.GetAll();
            return View(races);
        }


        public async Task<IActionResult> Create()

        {
            RaceVM raceVM = new RaceVM();
            var selList = new SelectList(await _speciesRepository.GetAll(), "SpeciesId", "SpeciesName");
            raceVM.SpeciesList = selList;
            return View(raceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RaceId, RaceName, SpeciesId")] RaceVM newRaceVM)
        {

            if (ModelState.IsValid)
            {
                var newRace = _mapper.Map<Race>(newRaceVM);
                await _raceRepository.AddRace(newRace);
                return RedirectToAction("Index");
            }

            var selList = new SelectList(await _speciesRepository.GetAll(), "SpeciesId", "SpeciesName", newRaceVM.SpeciesId);
            newRaceVM.SpeciesList = selList;
            return View(newRaceVM);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            var allRaces = await _raceRepository.GetAll();
            if (id == null || allRaces.Any() == false)
            {


                return NotFound();
            }

            var race = await _raceRepository.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }

            var raceVM = _mapper.Map<RaceVM>(race);
            var selList = new SelectList(await _speciesRepository.GetAll(), "SpeciesId", "SpeciesName");
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
                await _raceRepository.Update(race);
                return RedirectToAction("Index");
            }
            var selList = new SelectList(await _speciesRepository.GetAll(), "SpeciesId", "SpeciesName", raceVM.SpeciesId);
            raceVM.SpeciesList = selList;
            return View(raceVM);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            var race =  await _raceRepository.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _raceRepository.RemoveById(id);
            return RedirectToAction(nameof(Index));
        }
    }


}