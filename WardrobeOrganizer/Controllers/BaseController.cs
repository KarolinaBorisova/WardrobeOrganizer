using Microsoft.AspNetCore.Mvc;

namespace WardrobeOrganizer.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
