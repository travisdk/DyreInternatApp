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
        }

        public List<Race> GetAll()
        {
            return _appDbContext.Races.Include(r => r.Species).ToList();
            
        }
    }
}
