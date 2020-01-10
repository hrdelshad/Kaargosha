using Microsoft.AspNetCore.Mvc;

namespace Kargosha.Mvc.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}