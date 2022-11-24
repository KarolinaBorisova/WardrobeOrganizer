using Microsoft.AspNetCore.Mvc;

namespace WardrobeOrganizer.Controllers
{
    public class ClothesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
