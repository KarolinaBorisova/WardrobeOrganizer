using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Core.Services;

namespace WardrobeOrganizer.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IAccessoriesService accessoriesService;

        public AccessoriesController(IAccessoriesService _accessoriesService)
        {
            this.accessoriesService = _accessoriesService;
        }

        public async Task<IActionResult> All(int storageId)
        {
            var model = await accessoriesService.AllAccessories(storageId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int storageId, string category)
        {
            var model = new AddAccessoriesViewModel()
            {
                StorageId = storageId,
                Category = category
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAccessoriesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }

            var storageId = model.StorageId;
            int id = await accessoriesService.AddAccessories(model);
            return RedirectToAction("AccessoriesByCategory", "Accessories", new { storageId, model.Category });

        }

        [HttpGet]
        public async Task<IActionResult> AccessoriesByCategory(int storageId, string category)
        {
            var model = await accessoriesService.AllAccessoriesByCategory(storageId, category);
            return View(model);
        }
    }
}
