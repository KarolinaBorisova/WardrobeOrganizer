using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Controllers
{
    public class ClothesController : Controller
    {
        public async Task<IActionResult> All()
        {
            var model = new AllClothesViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddClothesViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClothesViewModel model)
        {
            int id = 1;
            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new DetailsClothesViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new EditClothesViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClothesViewModel model)
        {
            return RedirectToAction(nameof(Details), new { id, model });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }
    }
}
