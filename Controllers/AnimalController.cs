using DyreInternatApp.Domain.Models;
using DyreInternatApp.BL.Services;
using DyreInternatApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;


namespace DyreInternatApp.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalService  animalService, IMapper mapper)
        {
            _animalService = animalService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var animals = await _animalService.GetAllAnimals();
            var animalsVM = _mapper.Map<List<AnimalVM>>(animals);
            return View(animalsVM);    
        }
    }
}
