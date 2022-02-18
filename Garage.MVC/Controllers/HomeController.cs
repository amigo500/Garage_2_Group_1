using Microsoft.AspNetCore.Mvc;

namespace Garage_2_Group_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
