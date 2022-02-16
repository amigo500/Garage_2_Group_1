using AutoMapper;
using Garage_2_Group_1.Models.VehicleVeiwModels;

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
