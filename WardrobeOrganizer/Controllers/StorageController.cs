using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
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
        private readonly ILogger logger;
        


        public StorageController(IStorageService _storageService,
            IFamilyService _familyService,
            IHouseService _houseService,
            ILogger<StorageController> _logger)
        {
            this.storageService = _storageService;
            this.familyService = _familyService;
            this.houseService = _houseService;
            this.logger = _logger;
         
        }
        //All Storages in DB
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

            int id = await storageService.AddStorage(model);
            return RedirectToAction("Info", "Storage", new { id }); //Change to stoargeId
        }

        public async Task<IActionResult> Content(int id)
        {
            var model = new ContentStorageViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await storageService.ExistsById(id)==false)
            {
                return RedirectToAction(nameof(All));
            }
            var storage = await storageService.GetStorageById(id);
            var model = new InfoStorageViewModel()
            {
                Id = id,
                Name = storage.Name,
                
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( InfoStorageViewModel model)
        {
             if (await storageService.ExistsById(model.Id) == false)
            {
                ModelState.AddModelError("", "Storage does not exist");
                return RedirectToAction(nameof(All));
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await storageService.Edit(model);
            return RedirectToAction("Info", "Storage", new { model.Id });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (await storageService.ExistsById(id) == false)
            {
                ModelState.AddModelError("", "Storage does not exist");
                return RedirectToAction(nameof(All));
            }

            var storage = await storageService.GetStorageById(id);
            var houseId = storage.House.Id;
            await storageService.Delete(id);

            return RedirectToAction("Info", "House", new {houseId});
        }
        

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            var model = await storageService.GetStorageById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddItem(int id)
        {
            var model = await storageService.GetStorageById(id);

            return View(model);
        }

    }
}
