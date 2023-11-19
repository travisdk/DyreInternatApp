using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface IRaceRepository
    {
        void AddRace(Race newRace);
        List<Race> GetAll();

        Race? GetRaceById(int? id);
        void Update(Race race);

        void RemoveById(int id); 
    }
}
