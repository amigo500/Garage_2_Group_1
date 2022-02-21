using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Services
{
    public class VehicleTypeSelectListService : IVehicleTypeSelectListService
    {
        private readonly GarageContext2 _db;

        public VehicleTypeSelectListService(GarageContext2 context)
        {
            _db = context;
        }

        public async Task<List<SelectListItem>> GetSelectListAsync()
        {
            var typesList = new List<SelectListItem>();
            var types = await _db.VehicleType.ToListAsync();

            types.ForEach(type => typesList.Add(
                new SelectListItem { Text = type.Name, Value = type.Id.ToString() }
            ));

            return typesList;
        }
        
        public async Task<List<SelectListItem>> GetSelectListAsync(int id)
        {
            var typesList = new List<SelectListItem>();
            var types = await _db.VehicleType.ToListAsync();

            types.ForEach(type => typesList.Add(
                new SelectListItem { Text = type.Name, Value = type.Id.ToString(), Selected = (type.Id == id) }
            ));

            return typesList;
        }
    }
}
