using DyreInternatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DyreInternatApp.Repositories
{
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly AppDbContext _appDbContext;
        public SpeciesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddSpecies(Species newSpecies)
        {
            _appDbContext.Add(newSpecies);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Species>> GetAll()
        {
            return await _appDbContext.Species.ToListAsync();
        }
    }
}
