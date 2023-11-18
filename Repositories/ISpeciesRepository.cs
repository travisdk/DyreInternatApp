using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface ISpeciesRepository
    {
        void AddSpecies(Species newSpecies);
        List<Species> GetAll(); 
    }
}
