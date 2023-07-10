using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
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
    public class StorageController : BaseController
    {

        private readonly IStorageService storageService;
        private readonly IFamilyService familyService;
        private readonly IHouseService houseService;
        private readonly UserManager<User> userManager;
        private readonly ILogger logger;
        


        public StorageController(IStorageService _storageService,
            IFamilyService _familyService,
            IHouseService _houseService,
            UserManager<User> _userManager,
        ILogger<StorageController> _logger)
        {
            this.storageService = _storageService;
            this.familyService = _familyService;
            this.houseService = _houseService;
            this.userManager = _userManager;
            this.logger = _logger;
         
        }
        //All Storages in DB
        public async Task<IActionResult> All(int houseId)
        {
            if (await houseService.ExistsById(houseId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid house";
                return RedirectToAction("Error", "Home");
            }

            var familyId = await familyService.GetFamilyId(User.Id());
            var house = await houseService.GetHouseById(houseId);

            if (house.FamilyId != familyId)
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            var model = await storageService.AllStorages(houseId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int houseId)
        {
            if (await houseService.ExistsById(houseId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid house";
                return RedirectToAction("Error", "Home");
            }

            var familyId = await familyService.GetFamilyId(User.Id());
            var house = await houseService.GetHouseById(houseId);

            if (house.FamilyId != familyId)
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            var model = new AddStorageViewModel()
            {
                   HouseId = houseId
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStorageViewModel model)
        {
            if (await houseService.ExistsById(model.HouseId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid house";
                return RedirectToAction("Error", "Home");
            }
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Try again";
                return View(model);
            }
            var familyId = await familyService.GetFamilyId(User.Id());
            var house = await houseService.GetHouseById(model.HouseId);

            if (house.FamilyId != familyId)
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

                try
            {
                int id = await storageService.AddStorage(model);
                return RedirectToAction("Info", "Storage", new { id });
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return RedirectToAction("Add", "Storage");
            }     
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int id)
        {
            if (await storageService.ExistsById(id)==false)
            {
                TempData[MessageConstant.ErrorMessage] = "Can`t find this storage";
                return RedirectToAction("Error", "Home");
            }
            var storage = await storageService.GetStorageById(id);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (storage.House.FamilyId != familiId )
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
               return RedirectToAction("Error", "Home");
            }
            var model = new InfoStorageViewModel()
            {
                Id = id,
                Name = storage.Name,
                
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit( InfoStorageViewModel model)
        {
             if (await storageService.ExistsById(model.Id) == false)
            {
                ModelState.AddModelError("", "Can`t find this storage");
                return RedirectToAction("Error", "Home");
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }
            var storage = await storageService.GetStorageById(model.Id);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (storage.House.FamilyId != familiId)
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                await storageService.Edit(model);
                return RedirectToAction("Info", "Storage", new { model.Id });
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return RedirectToAction("Edit", "Storage");
            }
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await storageService.ExistsById(id) == false)
            {
                ModelState.AddModelError("", "Can`t find this storage");
                return RedirectToAction("Error", "Home");
            }

            var storage = await storageService.GetStorageById(id);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (storage.House.FamilyId != familiId)
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            var houseId = storage.House.Id;

            try
            {
                await storageService.Delete(id);
            }
            catch (Exception)
            {

                TempData[MessageConstant.WarningMessage] = "Something went wrong! Try again";
            }
             return RedirectToAction("Info", "House", new {houseId});
        }
        

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            if (await storageService.ExistsById(id) == false)
            {
                ModelState.AddModelError("", "Can`t find this storage");
                return RedirectToAction("Error", "Home");
            }
            var storage = await storageService.GetStorageById(id);
            int familiId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());


            if (storage.House.FamilyId != familiId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            return View(storage);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> AddItem(int storageId)
        {
            if (await storageService.ExistsById(storageId) == false)
            {
                ModelState.AddModelError("", "Can`t find this storage");
                return RedirectToAction("Error", "Home");
            }
            var storage = await storageService.GetStorageById(storageId);
            int familiId = await familyService.GetFamilyId(User.Id());


            if (storage.House.FamilyId != familiId)
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            return View(storage);
        }

    }
}
