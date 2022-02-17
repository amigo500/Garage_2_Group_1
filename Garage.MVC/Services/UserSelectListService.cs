using Microsoft.AspNetCore.Mvc.Rendering;

namespace Garage_2_Group_1.Services
{
    public class UserSelectListService : IUserSelectListService
    {
        private readonly GarageContext2 _db;

        public UserSelectListService(GarageContext2 context)
        {
            _db = context;
        }

        public async Task<List<SelectListItem>> GetSelectListAsync()
        {
            var userList = new List<SelectListItem>();
            var users = await _db.User.OrderBy(u => u.FirstName).ToListAsync();

            users.ForEach(user => userList.Add(
                new SelectListItem { Text = $"{user.FirstName} {user.LastName}", Value = user.SSN.ToString() }
            ));

            return userList;
        }
    }
}
