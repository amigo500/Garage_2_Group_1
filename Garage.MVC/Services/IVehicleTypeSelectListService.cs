using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Services
{
    public interface IVehicleTypeSelectListService
    {
        Task<List<SelectListItem>> GetSelectListAsync();
    }
}