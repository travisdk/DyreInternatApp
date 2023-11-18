using DyreInternatApp.Models;
using DyreInternatApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DyreInternatApp.Controllers
{
    public class RaceController : Controller
    {
        private IRaceRepository _raceRepository;
        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        public IActionResult Index()
        {
            var races = _raceRepository.GetAll();
            return View(races);
        }


        public IActionResult Create()
        {
            //ViewData["CID"] = new SelectList(_context.Customers, "CID", "CID", order.CID);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RaceId, RaceName, SpeciesId")] Race newRace)
        {

            if (ModelState.IsValid)
            {
                _raceRepository.AddRace(newRace);
                return RedirectToAction("Index");
            }

            return View(newRace);

        }
    }
}
