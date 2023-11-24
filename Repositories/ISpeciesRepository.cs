using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface ISpeciesRepository
    {
        Task AddSpecies(Species newSpecies);
        Task<List<Species>> GetAll(); 
    }
}
