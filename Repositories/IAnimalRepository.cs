using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface IAnimalRepository 
    {
        Task AddAnimal(Animal newAnimal, IFormFile? imageFile);
        Task< List<Animal>> GetAll();

        Task<Animal?> GetAnimalById(int? id);
        Task UpdateAnimal(Animal animal, IFormFile? imageFile);

        Task RemoveById(int id);
    }
}
