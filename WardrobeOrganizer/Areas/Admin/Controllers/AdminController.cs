using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WardrobeOrganizer.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
