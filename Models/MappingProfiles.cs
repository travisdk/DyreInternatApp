using DyreInternatApp.Models.ViewModels;
using AutoMapper;
namespace DyreInternatApp.Models.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Race, RaceVM>();
            CreateMap<RaceVM, Race>();

        }
    }
}
