using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WardrobeOrganizer.Controllers
{
   [Authorize]
    public class ItemController : Controller
    {
       // public async Task<IActionResult> Add()
       // {
       //     var model = new SportAddViewModel()
       //     {
       //         Halls = await hallService.AllHalls()
       //     };
       //     return View(model);
       // }
    }
}
