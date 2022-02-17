using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Services
{
    public interface IUserSelectListService
    {
        Task<List<SelectListItem>> GetSelectListAsync();
    }
}