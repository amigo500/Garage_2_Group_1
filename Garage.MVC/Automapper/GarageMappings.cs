using AutoMapper;
using Garage_2_Group_1.Models.VehicleViewModels;

namespace Garage_2_Group_1.Automapper
{
    public class GarageMappings : Profile
    {
        public GarageMappings()
        {
            CreateMap<Vehicle, VehicleCreateViewModel>();
        }
    }
}
