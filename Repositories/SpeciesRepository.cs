using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly AppDbContext _appDbContext;
        public SpeciesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddSpecies(Species newSpecies)
        {
            
            _appDbContext.Add(newSpecies);
            _appDbContext.SaveChanges();
        }

        public List<Species> GetAll()
        {
            return _appDbContext.Species.ToList();
        }
    }
}
