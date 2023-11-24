using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface IRaceRepository
    {
        Task AddRace(Race newRace);
        Task<List<Race>> GetAll();

        Task<Race?> GetRaceById(int? id);
        Task Update(Race race);

        Task RemoveById(int id); 
    }
}
