using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using DyreInternatApp.SharedViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DyreInternatApp.DAL.Repositories;
using DyreInternatApp.SharedModels.Models;
using DyreInternatApp.BL.Services;

namespace DyreInternatApp.Areas.Admin.Controllers { 

    [Area("Admin")]
    [Authorize]
    public class AnimalAdminController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IRaceService _raceService;
        private readonly IMapper _mapper;

        public AnimalAdminController(IAnimalService animalService, IRaceService raceService, IMapper mapper)
        {
            _animalService = animalService;
            _raceService = raceService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _animalService.GetAllAnimals());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var animalVM = await _animalService.GetAnimalById(id);
            if (animalVM == null)
            {
                return NotFound();
            }
            return View(animalVM);
        }

        public async Task<IActionResult> Create()
        {
            AnimalVM animalVM = new AnimalVM();

            // REFACTOR THIS MAYBE ?? - SEVERAL PLACES
            animalVM.RaceList = await _raceService.GetRacesSelectList();

            return View(animalVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalName,RaceId,Price,IsVaccinated,TagCode,DateOfBirth,Weight,Notes, ImageFileName, ImageFile")] AnimalVM animalVM)
        {
            if (ModelState.IsValid)
            {
               
                await _animalService.AddAnimal(animalVM);
                return RedirectToAction(nameof(Index));
            }
            animalVM.RaceList = await _raceService.GetRacesSelectList();

            return View(animalVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var allAnimals = await _animalService.GetAllAnimals();

            if (id == null || allAnimals.Any() == false)
            {
                return NotFound();
            }
            var animalVM =  await _animalService.GetAnimalById(id);
            if (animalVM == null)
            {
                return NotFound();
            }
            animalVM.RaceList = await _raceService.GetRacesSelectList(); 
            return View(animalVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //TODO: missing ID check + Concurrency stuff normally found here...
        public async Task<IActionResult> Edit([Bind("AnimalId,AnimalName,RaceId,Price,IsVaccinated,TagCode,DateOfBirth,Weight,Notes, ImageFileName, ImageFile")] AnimalVM animalVM)
        {
            if (ModelState.IsValid)
            {
                await _animalService.UpdateAnimal(animalVM);
                return RedirectToAction("Index");
            }
            animalVM.RaceList = await _raceService.GetRacesSelectList();  // TODO => Servicen
            return View(animalVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var animalVM = await _animalService.GetAnimalById(id);
            if (animalVM == null)
            {
                return NotFound();
            }
            return View(animalVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allAnimals = await _animalService.GetAllAnimals();

            if (allAnimals == null)
            {
                return Problem("Entity set 'AppDbContext.Animals'  is null.");
            }

            await _animalService.RemoveAnimalById(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
