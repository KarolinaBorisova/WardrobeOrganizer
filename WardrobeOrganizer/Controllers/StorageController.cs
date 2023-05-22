using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.Design;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    [Authorize]
    public class StorageController : Controller
    {

        private readonly IStorageService storageService;
        private readonly IFamilyService familyService;
        private readonly IHouseService houseService;
        


        public StorageController(IStorageService _storageService,
            IFamilyService _familyService,
            IHouseService _houseService)
        {
            this.storageService = _storageService;
            this.familyService = _familyService;
            this.houseService = _houseService;
         
        }

        public async Task<IActionResult> All()
        {
            int familiId = await familyService.GetFamilyId(User.Id());
            var model = await storageService.AllStorages(familiId);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int houseId)
        {
            var model = new AddStorageViewModel()
            {
                   HouseId = houseId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStorageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Try again";
                return View(model);
            }

        
        //    int houseId = await houseService.GetHouseId(User.Id());

            int storgeId = await storageService.AddStorage(model, model.HouseId);
            return RedirectToAction("Info", "House", new { model.HouseId }); //Change to stoargeId
        }

        public async Task<IActionResult> Content(int id)
        {
            var model = new ContentStorageViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new EditStorageViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditStorageViewModel model)
        {
           return RedirectToAction(nameof (Content), new { id, model });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }
        

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            var model = new InfoStorageViewModel();
            return View(model);
        }

    }
}
