using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface IAnimalRepository 
    {
        Task AddAnimal(Animal newAnimal, IFormFile? imageFile);
        List<Animal> GetAll();

        Animal? GetAnimalById(int? id);
        void Update(Animal animal);

        void RemoveById(int id);
    }
}
