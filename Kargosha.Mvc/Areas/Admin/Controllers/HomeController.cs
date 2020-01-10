using Microsoft.AspNetCore.Mvc;

namespace Kargosha.Mvc.Areas.Admin
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}