using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface IAnimalRepository 
    {
        void AddAnimal(Animal newAnimal);
        List<Animal> GetAll();

        Animal? GetAnimalById(int? id);
        void Update(Animal animal);

        void RemoveById(int id);
        Task<string> AddAnimalImageFile(IFormFile? imageFile, string animalName);
    }
}
