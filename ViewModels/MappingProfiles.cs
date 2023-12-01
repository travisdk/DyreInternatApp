using AutoMapper;
using DyreInternatApp.Domain.Models;
namespace DyreInternatApp.ViewModels { 
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Race, RaceVM>();
            CreateMap<RaceVM, Race>();
            CreateMap<Animal, AnimalVM>();
            CreateMap<AnimalVM, Animal>();
            CreateMap<Species, SpeciesVM>();
            CreateMap<SpeciesVM, Species>();
            CreateMap<Order, OrderVM>();    
            CreateMap<OrderVM, OrderVM>();

        }
    }
}
