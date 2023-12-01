
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using DyreInternatApp.BL.Services;
using DyreInternatApp.ViewModels;
using DyreInternatApp.Domain.Models;


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
            var animal = await _animalService.GetAnimalById(id);
            var animalVM = _mapper.Map<AnimalVM>(animal);

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
                var animal = _mapper.Map<Animal>(animalVM);
                await _animalService.AddAnimal(animal, animalVM.ImageFile);
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
            var animal =  await _animalService.GetAnimalById(id);
            var animalVM = _mapper.Map<AnimalVM>(animal);

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
                var animal = _mapper.Map<Animal>(animalVM);
                await _animalService.UpdateAnimal(animal,  animalVM.ImageFile);
                return RedirectToAction("Index");
            }
            animalVM.RaceList = await _raceService.GetRacesSelectList();  // TODO => Servicen
            return View(animalVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var animal = await _animalService.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
            var animalVM = _mapper.Map<AnimalVM>(animal);
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
