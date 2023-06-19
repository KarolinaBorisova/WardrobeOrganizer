using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Member;
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

            var model = await clothesService.AllClothesByCategory(storageId, category);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int storageId, string category)
        {
            var model = new AddClothesViewModel()
            {
                StorageId = storageId,
                Category = category
                
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

        public async Task<IActionResult> Details(int clothingId)
        {
            var model = await clothesService.GetClothingById(clothingId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int clothingId)
        {
            if (await clothesService.ExistsById(clothingId) == false)
            {
                logger.LogInformation("Clothing with id {0} not exist", clothingId);
                return RedirectToAction(nameof(All));
            }
            var clothing = await clothesService.GetClothingById(clothingId);
           
            var model = new DetailsClothesViewModel()
            {
               Id= clothingId,
               Size =  clothing.Size,
               SizeHeight = clothing.SizeHeight,
               StorageId = clothing.StorageId,
               Category = clothing.Category,
               Color = clothing.Color,
               Description = clothing.Description,
               ImgUrl = clothing.ImgUrl,
               Name = clothing.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( DetailsClothesViewModel model)
        {
            if (await clothesService.ExistsById(model.Id) == false)
            {
                logger.LogInformation("Clothing with id {0} not exist", model.Id);
                ModelState.AddModelError("", "Clothing does not exist");
                return View();
            }
            if (ModelState.IsValid == false)
            {
                return View(model);

            }

            try
            {
                await clothesService.Edit(model);
                TempData[MessageConstant.SuccessMessage] = "Clothing edited";
            }
            catch (Exception)
            {
                logger.LogInformation("Failed to edit member with id {0}", model.Id);

            }
            var clothingId = model.Id;
            //  return RedirectToAction("Info", "Member", new { model.Id });
            return RedirectToAction("Details", "Clothes", new { clothingId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int clothingId)
        {
            if (await clothesService.ExistsById(clothingId) == false)
            {
                ModelState.AddModelError("", "Clothing does not exist");
                return RedirectToAction("Clothes", "All");
            }
            var clothing = await clothesService.GetClothingById(clothingId);
            await clothesService.DeleteById(clothingId);
            return RedirectToAction(nameof(All), new {clothing.StorageId});
        }
    }
}
