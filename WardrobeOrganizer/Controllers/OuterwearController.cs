using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Core.Services;

namespace WardrobeOrganizer.Controllers
{
    public class OuterwearController : Controller
    {

        private readonly IOuterwearService outerwearService;

        public OuterwearController(IOuterwearService outerwearService)
        {
            this.outerwearService = outerwearService;
        }

        public async Task<IActionResult> All(int storageId)
        {
            var model = await outerwearService.AllOutwear(storageId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int storageId, string category)
        {
            var model = new AddOuterwearViewModel()
            {
                StorageId=  storageId,
                Category=category
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOuterwearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }

            var storageId = model.StorageId;
            int id = await outerwearService.AddOuterWear(model);
            return RedirectToAction("OuterwearByCategory", "Outerwear", new { storageId, model.Category });

        }

        [HttpGet]
        public async Task<IActionResult> OuterwearByCategory(int storageId, string category)
        {
            var model = await outerwearService.AllOuterwearByCategory(storageId, category);
            return View(model);
        }

        public async Task<IActionResult> Details(int outerwearId)
        {
            var model = await outerwearService.DetailsOuterwear(outerwearId);
            return View(model);
        }
    }
}
