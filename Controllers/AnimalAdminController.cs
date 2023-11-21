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

namespace DyreInternatApp.Controllers
{


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


        public IActionResult Index()
        {
            List<Animal> allAnimals = _animalRepository.GetAll();
            if (allAnimals.Count == 0)
                return View();
            var animalsVM = _mapper.Map<List<AnimalVM>>(allAnimals);

 
            return View(animalsVM);
        }

        // GET: Animals/Details/5
        public  IActionResult  Details(int? id)
        {

            var animal =  _animalRepository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        public IActionResult Create()
        {
            AnimalVM animalVM = new AnimalVM();
            var allAnimalTypes = _raceRepository.GetAll().Select(s => new
            {
                RaceId = s.RaceId,
                Description = $"{s.Species.SpeciesName} / {s.RaceName}"
            }).ToList();
            
            var selList = new SelectList(allAnimalTypes, "RaceId", "Description");
            animalVM.RaceList = selList;
            return View(animalVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalName,RaceId,Price,IsVaccinated,TagCode,DateOfBirth,Weight,Notes, ImageId, ImageFile")] AnimalVM animalVM)
        {
            if (ModelState.IsValid)
            {
                var animal = _mapper.Map<Animal>(animalVM);

                if (animalVM.ImageFile != null)
                {

                    animal.ImageFileName = await _animalRepository.AddAnimalImageFile(animalVM.ImageFile, animalVM.AnimalName);

                    if (animal.ImageFileName == null) { throw new("Error writing animal photo file to disk");  }
                  
                }
                _animalRepository.AddAnimal(animal);

                return RedirectToAction(nameof(Index));
            }
   
            return View(animalVM);
        }

        // GET: Animals/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _animalRepository.GetAll().Any() == false)
            {
                return NotFound();
            }
            var animal = _animalRepository.GetAnimalById(id);
            if (animal == null)
            {
                return NotFound();
            }
            var animalVM = _mapper.Map<AnimalVM>(animal);
            var allAnimalTypes = _raceRepository.GetAll().Select(s => new
            {
                RaceId = s.RaceId,
                Description = $"{s.Species.SpeciesName} / {s.RaceName}"
            }).ToList();

            var selList = new SelectList(allAnimalTypes, "RaceId", "Description");
            animalVM.RaceList = selList;
            return View(animalVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 

        // missing ID check + Concurrency stuff normally found here...
        public IActionResult Edit([Bind("AnimalId,AnimalName,RaceId,Price,IsVaccinated,TagCode,DateOfBirth,Weight,Notes,ImageId")] AnimalVM animalVM)
        {
            if (ModelState.IsValid)
            {

                var animal = _mapper.Map<Animal>(animalVM);
                _animalRepository.Update(animal);
                return RedirectToAction("Index");
            }

            var allAnimalTypes = _raceRepository.GetAll().Select(s => new
            {
                RaceId = s.RaceId,
                Description = $"{s.Species.SpeciesName} / {s.RaceName}"
            }).ToList();

            var selList = new SelectList(allAnimalTypes, "RaceId", "Description");
            animalVM.RaceList = selList;
            return View(animalVM);
        }

        //// GET: Animals/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Animals == null)
        //    {
        //        return NotFound();
        //    }

        //    var animal = await _context.Animals
        //        .Include(a => a.Race)
        //        .FirstOrDefaultAsync(m => m.AnimalId == id);
        //    if (animal == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(animal);
        //}

        //// POST: Animals/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Animals == null)
        //    {
        //        return Problem("Entity set 'AppDbContext.Animals'  is null.");
        //    }
        //    var animal = await _context.Animals.FindAsync(id);
        //    if (animal != null)
        //    {
        //        _context.Animals.Remove(animal);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AnimalExists(int id)
        {
            return (_animalRepository.GetAll()?.Any(e => e.AnimalId == id)).GetValueOrDefault();
        }
    }
}
