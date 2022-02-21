using AutoMapper;
using Garage_2_Group_1.Models.VehicleVeiwModels;


namespace Garage_2_Group_1.Automapper
{
    public class GarageMappings : Profile
    {
        public GarageMappings()
        {
            CreateMap<Vehicle, VehicleCreateViewModel>().ReverseMap();
            CreateMap<Vehicle, VehicleIndexViewModel>()
                .ForMember(dest => dest.FullName, from => from.MapFrom(u => u.User.FirstName + " " + u.User.LastName))
                .ForMember(dest => dest.VehicleTypeName, from => from.MapFrom(t => t.VehicleType.Name))
                .ForMember(dest => dest.VehicleColor, from => from.MapFrom(c => c.Color));
                .ForMember(dest => dest.VehicleTypeId, from => from.MapFrom(t => t.VehicleType.Id));
        }
    }
}
