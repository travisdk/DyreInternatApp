using DyreInternatApp.Models;
using DyreInternatApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DyreInternatApp.ViewModels;

namespace DyreInternatApp.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalRepository  animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            List<Animal> allAnimals = await _animalRepository.GetAll();
            var allAnimalsVM = _mapper.Map<List<AnimalVM>>(allAnimals);
            return View(allAnimalsVM);
        }
    }
}
