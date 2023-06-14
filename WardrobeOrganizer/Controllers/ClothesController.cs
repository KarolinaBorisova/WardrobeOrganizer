using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;

namespace WardrobeOrganizer.Controllers
{
    public class ClothesController : Controller
    {
        private readonly IClothesService clothesService;
        private readonly IFamilyService familyService;
        private readonly ILogger logger;

        public ClothesController(IClothesService _clothesService,
        IFamilyService _familyService,
        ILogger<ClothesController> _logger)
        {
            this.clothesService = _clothesService;
            this.familyService = _familyService;
            this.logger = _logger;
        }   

        public async Task<IActionResult> All(int storageId)
        {
            
             var model = await clothesService.AllClothes(storageId);
            return View(model);
        }

        public async Task<IActionResult> ClothesByCategory(int storageId, string category)
        {

            var model = await clothesService.AllClothes(storageId, category);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int storageId, string clothesCategory)
        {
            var model = new AddClothesViewModel()
            {
                StorageId = storageId,
                Category = clothesCategory
                
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClothesViewModel model)
        {
            if(!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }
            var storageId = model.StorageId;
            int id = await clothesService.AddClothes(model);
            return RedirectToAction("ClothesByCategory", "Clothes", new { storageId , model.Category});
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
