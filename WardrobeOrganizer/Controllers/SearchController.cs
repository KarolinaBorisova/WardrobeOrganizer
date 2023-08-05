using Microsoft.AspNetCore.Mvc;

namespace WardrobeOrganizer.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
