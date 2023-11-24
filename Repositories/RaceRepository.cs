using DyreInternatApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DyreInternatApp.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        private readonly AppDbContext _appDbContext;

        public RaceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddRace(Race newRace)
        {
            _appDbContext.Races.Add(newRace);
             await  _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Race>> GetAll()
        {
            return await _appDbContext.Races.Include(r => r.Species).OrderBy(r => r.Species.SpeciesName).ThenBy(r=>r.RaceName).ToListAsync();    
        }

        public async Task<Race?> GetRaceById(int? id)
        {
            return await _appDbContext.Races.Include(r => r.Species).FirstOrDefaultAsync(r => r.RaceId == id); 
        }

        public async Task RemoveById(int id)
        {
            var race = await GetRaceById(id);
            _appDbContext.Races.Remove(race);
            await  _appDbContext.SaveChangesAsync();
        }

        public async Task Update(Race race)
        {
            _appDbContext.Races.Update(race);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
