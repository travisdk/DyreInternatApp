using DyreInternatApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace DyreInternatApp.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AnimalRepository(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task AddAnimal(Animal newAnimal, IFormFile? imageFile)
        {
            if (imageFile != null)
            {
                var fileName = newAnimal.AnimalName + "_" + Guid.NewGuid().ToString() + @".jpg"; // CONVERTER HERE !!
                var physicalPath = Path.Combine(_webHostEnvironment.WebRootPath, @"img\animals\", fileName);
                using (var stream = System.IO.File.Create(physicalPath))
                {
                    await imageFile.CopyToAsync(stream);
                }
                newAnimal.ImageFileName = fileName;
            }
            _appDbContext.Animals.Add(newAnimal);
            _appDbContext.SaveChanges();
        }

        public List<Animal>? GetAll()
        {
            return _appDbContext.Animals.Include(animal => animal.Race).ThenInclude(race => race.Species).ToList();
        }

        public Animal? GetAnimalById(int? id)
        {
           return _appDbContext.Animals.Include(animal => animal.Race).ThenInclude(race => race.Species)
                .FirstOrDefault(animal => animal.AnimalId == id);    
        }

        public void RemoveById(int id)
        {
            var animal = GetAnimalById(id);
            _appDbContext.Animals.Remove(animal);
            _appDbContext.SaveChanges();
        }

        public void Update(Animal animal)
        {
            _appDbContext.Animals.Update(animal);   
            _appDbContext.SaveChanges();
        }
    }
}
