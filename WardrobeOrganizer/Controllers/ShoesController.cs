using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Core.Services;

namespace WardrobeOrganizer.Controllers
{
    public class ShoesController : Controller
    {

        private readonly IShoesService shoesService;

        public ShoesController(IShoesService _shoesService)
        {
            this.shoesService = _shoesService;
        } 

        [HttpGet]
        public IActionResult Add(int storageId, string category)
        {
            var model = new AddShoesViewModel()
            {
                StorageId = storageId,
                Category = category
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddShoesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }
            var storageId = model.StorageId;
            int id = await shoesService.AddShoes(model);
            return RedirectToAction("ShoesByCategory", "Shoes", new { storageId, model.Category });
        }

        public async Task<IActionResult> ShoesByCategory(int storageId, string category)
        {
            var model = await shoesService.AllShoesByCategory(storageId, category);

            return View(model);
        }

        public async Task<IActionResult> All(int storageId)
        {
            var model = await shoesService.AllShoes(storageId);

            return View(model);
        }

    }
}
