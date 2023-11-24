using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DyreInternatApp.Models;
using DyreInternatApp.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using DyreInternatApp.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DyreInternatApp.Areas.Admin.Controllers { 



    [Area("Admin")]
    [Authorize]
    public class AnimalAdminController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public AnimalAdminController(IAnimalRepository animalRepository, IRaceRepository raceRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
            List<Animal> allAnimals =  await _animalRepository.GetAll();
            if (allAnimals.Count == 0)
            {
                return View();
            }
            var animalsVM = _mapper.Map<List<AnimalVM>>(allAnimals);
            return View(animalsVM);
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var animal = await _animalRepository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        public async Task<IActionResult> Create()
        {
            AnimalVM animalVM = new AnimalVM();
            animalVM.RaceList = await GetRacesSelectList();
            return View(animalVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalName,RaceId,Price,IsVaccinated,TagCode,DateOfBirth,Weight,Notes, ImageFileName, ImageFile")] AnimalVM animalVM)
        {
            if (ModelState.IsValid)
            {
                var animal = _mapper.Map<Animal>(animalVM);
                await _animalRepository.AddAnimal(animal, animalVM.ImageFile);
                return RedirectToAction(nameof(Index));
            }
            return View(animalVM);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var allAnimals = await _animalRepository.GetAll();
            if (id == null || allAnimals.Any() == false)
            {
                return NotFound();
            }
            var animal =  await _animalRepository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
        
            var animalVM = _mapper.Map<AnimalVM>(animal);
            animalVM.RaceList = await GetRacesSelectList();
            return View(animalVM);
        }


 
        [HttpPost]
        [ValidateAntiForgeryToken]

        //TODO: missing ID check + Concurrency stuff normally found here...
        public async Task<IActionResult> Edit([Bind("AnimalId,AnimalName,RaceId,Price,IsVaccinated,TagCode,DateOfBirth,Weight,Notes, ImageFileName, ImageFile")] AnimalVM animalVM)
        {
            if (ModelState.IsValid)
            {
                var animal = _mapper.Map<Animal>(animalVM);
                await _animalRepository.UpdateAnimal(animal, animalVM.ImageFile);
                return RedirectToAction("Index");
            }
            animalVM.RaceList = await GetRacesSelectList();
            return View(animalVM);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var animal = await _animalRepository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allAnimals = await _animalRepository.GetAll();
            if (allAnimals == null)
            {
                return Problem("Entity set 'AppDbContext.Animals'  is null.");
            }

            await _animalRepository.RemoveById(id);
            return RedirectToAction(nameof(Index));
        }
        private async Task<SelectList> GetRacesSelectList()
        {
            var allRaces = await _raceRepository.GetAll();
            var allAnimalTypes = allRaces.Select(s => new
            {
                s.RaceId,
                Description = $"{s.Species.SpeciesName} / {s.RaceName}"
            });

            var selList = new SelectList(allAnimalTypes, "RaceId", "Description");
            return selList;
        }
    }
}
