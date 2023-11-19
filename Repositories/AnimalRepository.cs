using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly AppDbContext _appDbContext;

        public AnimalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddAnimal(Animal newAnimal)
        {
            _appDbContext.Animals.Add(newAnimal);
            _appDbContext.SaveChanges();
        }

        public List<Animal>? GetAll()
        {
            return _appDbContext.Animals?.ToList();
        }

        public Animal? GetAnimalById(int? id)
        {
           return _appDbContext.Animals.FirstOrDefault(animal => animal.AnimalId == id);    
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
