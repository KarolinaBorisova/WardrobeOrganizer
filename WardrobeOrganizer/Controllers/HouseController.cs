using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using System.ComponentModel.Design;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    public class HouseController : BaseController
    {

        private readonly IHouseService houseService;
        private readonly IFamilyService familyService;
        private readonly IStorageService storageService;
        private readonly ILogger logger;
        private readonly UserManager<User> userManager;



        public HouseController(IHouseService _houseService,
            IFamilyService _familyService,
            IStorageService _storageService,
            ILogger<HouseController> _logger,
            UserManager<User> _userManager)
        {
            this.houseService = _houseService;
            this.familyService = _familyService;
            this.storageService = _storageService;
            this.logger = _logger;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> All()
        {
            int familiId = await familyService.GetFamilyId(User.Id());
            var model = await houseService.AllHouses(familiId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public IActionResult Add()
        {
            var model = new AddHouseViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(AddHouseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Try again";
                return View(model);
            }

            try
            {
                int familiId = await familyService.GetFamilyId(User.Id());
                int houseId = await houseService.AddHouse(model, familiId);

                return RedirectToAction("Info", "House", new { houseId });
            }
            catch (Exception)
            {

                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return RedirectToAction("Add", "House");
            }
            
           
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int Id)
        {
            if (await houseService.ExistsById(Id) == false)
            {
                ModelState.AddModelError("", "Can`t find this house");
                return RedirectToAction("Error", "Home");
            }

            var house = await houseService.GetHouseById(Id);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (house.FamilyId != familiId)
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }


            var model = new InfoHouseViewModel()
            {
                Name = house.Name,
                Address = house.Address,
                Id = house.Id,
                FamilyId = house.FamilyId,
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(InfoHouseViewModel model)
        {
            if (await houseService.ExistsById(model.Id) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                return RedirectToAction("Error", "Home");
            }
            if (ModelState.IsValid == false)
            {
                return View(model);

            }
            var house = await houseService.GetHouseById(model.Id);
            int familiId = await familyService.GetFamilyId(User.Id());
            var houseId = house.Id;

            if (house.FamilyId != familiId)
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                await houseService.Edit(model);
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
            }
           
            return RedirectToAction("Info", "House", new {houseId});

        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await houseService.ExistsById(Id) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                return RedirectToAction("Error", "Home");
            }

            var house = await houseService.GetHouseById(Id);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (house.FamilyId != familiId)
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                await houseService.Delete(Id);

            }
            catch (Exception)
            {

                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
            }
            
            return RedirectToAction("Index", "Home");
        }
        

        [HttpGet]
        public async Task<IActionResult> Info(int houseId)
        {
            if (await houseService.ExistsById(houseId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Can`t find this house";
                return RedirectToAction("Error", "Home");
            }

            var house = await houseService.GetHouseById(houseId);
            int familiId = await familyService.GetFamilyId(User.Id());

            var user = await userManager.FindByIdAsync(User.Id());

            if (house.FamilyId != familiId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            var model = new InfoHouseViewModel()
            {
                Address = house.Address,
                FamilyId = house.FamilyId,
                Name = house.Name,
                Storages = await storageService.AllStorages(houseId),
                Id = house.Id


            };
            return View(model);
        }


    }
}
