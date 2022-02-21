using AutoMapper;
using Garage.Entities;
using Garage_2_Group_1.Models.UserViewModels;
using Garage_2_Group_1.Models.VehicleVeiwModels;
using Garage_2_Group_1.Models.ViewModels;

namespace Garage_2_Group_1.Automapper
{
    public class HomeMappings : Profile
    {
        public HomeMappings()
        {
            CreateMap<Vehicle, ParkatronDetailsViewModel>()
                 .ForMember(dest => dest.RegisteredVehicleTypes, from => from.MapFrom(t => t.VehicleType))
                 .ForMember(dest => dest.NumberOfRegisteredVehicles, from => from.MapFrom(t => t.Vehicle.Count()))
                 .ForMember(dest => dest.NumberOfRegisteredUsers, from => from.MapFrom(t => t.User.Count()))
                 .ForMember(dest => dest.EarnedTotals, from => from.MapFrom(t => t.Receipt.Count()));

            // .ForMember(dest => dest.NumberOfRegisteredVehicles, from => from.MapFrom(v => v.))
        }
    }
}
