using DyreInternatApp.Models;

namespace DyreInternatApp.Repositories
{
    public interface IRaceRepository
    {
        void AddRace(Race newRace);
        List<Race> GetAll();

    }
}
