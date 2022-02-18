using AutoMapper;
using Garage.Entities;
using Garage_2_Group_1.Models.UserViewModels;

namespace Garage_2_Group_1.Automapper
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserCreateViewModel>().ReverseMap();
            CreateMap<User, UserIndexViewModel>();


            CreateMap<User, UserDetailsViewModel>()
                .ForMember(
                      dest => dest.RegisteredVehiclesAmount,
                      from => from.MapFrom(v => v.Vehicles.Count))
                .ForMember(dest => dest.FullName, from => from.MapFrom(u => u.FirstName + " " + u.LastName)
                );
         
            CreateMap<User, UserEditViewModel>().ReverseMap();
        }
    }
}
