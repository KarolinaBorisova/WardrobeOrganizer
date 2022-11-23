using Microsoft.AspNetCore.Mvc;

namespace WardrobeOrganizer.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
