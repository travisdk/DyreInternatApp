using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DyreInternatApp.Models;
using DyreInternatApp.Repositories;
using DyreInternatApp.Models.ViewModels;
using AutoMapper;

namespace DyreInternatApp.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalRepository animalRepository, IRaceRepository raceRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        // GET: Animals
        public IActionResult Index()
        {
            List<Animal> allAnimals = _animalRepository.GetAll();
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
        public async Task<IActionResult> Create([Bind("AnimalName,RaceId,Price,IsVaccinated,TagCode,DateOfBirth,Weight,Notes")] AnimalVM animalVM)
        {
            if (ModelState.IsValid)
            {
                var animal = _mapper.Map<Animal>(animalVM);
                _animalRepository.AddAnimal(animal);
                return RedirectToAction(nameof(Index));
            }
   
            return View(animalVM);
        }

        //// GET: Animals/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Animals == null)
        //    {
        //        return NotFound();
        //    }

        //    var animal = await _context.Animals.FindAsync(id);
        //    if (animal == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["RaceId"] = new SelectList(_context.Races, "RaceId", "RaceName", animal.RaceId);
        //    return View(animal);
        //}

        //// POST: Animals/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("AnimalId,AnimalName,RaceId,Price,IsVaccinated,TagCode,DateOfBirth,Weight,Notes")] Animal animal)
        //{
        //    if (id != animal.AnimalId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(animal);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AnimalExists(animal.AnimalId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["RaceId"] = new SelectList(_context.Races, "RaceId", "RaceName", animal.RaceId);
        //    return View(animal);
        //}

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

        //private bool AnimalExists(int id)
        //{
        //  return (_context.Animals?.Any(e => e.AnimalId == id)).GetValueOrDefault();
        //}
    }
}
