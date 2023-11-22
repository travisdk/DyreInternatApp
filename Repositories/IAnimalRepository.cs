using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface IAnimalRepository 
    {
        Task AddAnimal(Animal newAnimal, IFormFile? imageFile);
        List<Animal> GetAll();

        Animal? GetAnimalById(int? id);
        Task UpdateAnimal(Animal animal, IFormFile? imageFile);

        void RemoveById(int id);
    }
}
