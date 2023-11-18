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
        public void AddRace(Race newRace)
        {
            _appDbContext.Races.Add(newRace);
            _appDbContext.SaveChanges();
        }

        public List<Race> GetAll()
        {
            return _appDbContext.Races.Include(r => r.Species).OrderBy(r => r.Species.SpeciesName).ThenBy(r=>r.RaceName).ToList();    
            
        }

        public Race? GetRaceById(int? id)
        {
            return _appDbContext.Races.Include(r => r.Species).FirstOrDefault(r => r.RaceId == id); 
        }

        public void Update(Race race)
        {
            _appDbContext.Races.Update(race);
            _appDbContext.SaveChanges();
        }
    }
}
