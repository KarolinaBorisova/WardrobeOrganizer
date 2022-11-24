using Microsoft.AspNetCore.Mvc;

namespace WardrobeOrganizer.Controllers
{
    public class StorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
