using AutoMapper;
using DyreInternatApp.Models;
using DyreInternatApp.Models.ViewModels;
using DyreInternatApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DyreInternatApp.Controllers
{
    public class RaceController : Controller
    {
        private IRaceRepository _raceRepository;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly IMapper _mapper;

        public RaceController(IRaceRepository raceRepository, ISpeciesRepository speciesRepository, IMapper mapper)
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


        public IActionResult Create()
        {
            ViewData["SID"] = new SelectList(_speciesRepository.GetAll(), "SpeciesId", "SpeciesName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RaceId, RaceName, SpeciesId")] RaceVM newRaceVM)
        {

            if (ModelState.IsValid)
            {
                var newRace = _mapper.Map<Race>(newRaceVM);
                _raceRepository.AddRace(newRace);
                return RedirectToAction("Index");
            }
            ViewData["SID"] = new SelectList(_speciesRepository.GetAll(), "SpeciesId", "SpeciesName", newRaceVM.SpeciesId);
            return View(newRaceVM);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _raceRepository.GetAll().Any() == false)
            {


                return NotFound();
            }

            var race = _raceRepository.GetRaceById(id);
            if (race == null)
            {
                return NotFound();
            }
            ViewData["SID"] = new SelectList(_speciesRepository.GetAll(), "SpeciesId", "SpeciesName", race.SpeciesId);

            var raceVM = _mapper.Map<RaceVM>(race);
            return View(raceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("RaceId, RaceName, SpeciesId")]RaceVM raceVM)
        {

            if (ModelState.IsValid )
            {
                var race = _mapper.Map<Race>(raceVM);
                _raceRepository.Update(race);
                return RedirectToAction("Index");
            }

            return View(raceVM);  

        }
    }
}
