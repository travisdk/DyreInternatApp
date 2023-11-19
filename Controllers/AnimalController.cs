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
        public IActionResult Index()
        {
            List<Animal> allAnimals = _animalRepository.GetAll();
            var allAnimalsVM = _mapper.Map<List<AnimalVM>>(allAnimals);
            return View(allAnimalsVM);
        }
    }
}
