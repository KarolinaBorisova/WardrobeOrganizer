using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class HouseController : Controller
    {

        private readonly IHouseService houseService;
        private readonly IFamilyService familyService;
        private readonly IStorageService storageService;
        


        public HouseController(IHouseService _houseService,
            IFamilyService _familyService,
            IStorageService _storageService)
        {
            this.houseService = _houseService;
            this.familyService = _familyService;
            this.storageService = _storageService;
         
        }

        public async Task<IActionResult> All()
        {
            int familiId = await familyService.GetFamilyId(User.Id());
            var model = await houseService.AllHouses(familiId);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddHouseViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddHouseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Try again";
                return View(model);
            }
      
            int familiId = await familyService.GetFamilyId(User.Id());
      
            int houseId = await houseService.AddHouse(model, familiId);
            return RedirectToAction("Info", "House", new {houseId});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await houseService.ExistsById(id) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                return View();
            }

            var house = await houseService.GetHouseById(id);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (house.FamilyId != familiId)
            {
                //ModelState.AddModelError("", "Not allowed");
                return RedirectToAction("Index", "Home");
            }


            var model = new InfoHouseViewModel()
            {
                Name = house.Name,
                Address = house.Address,
                Id = house.Id,
                FamilyId = house.FamilyId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InfoHouseViewModel model)
        {
            if (await houseService.ExistsById(model.Id) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                return View();
            }
            if (ModelState.IsValid == false)
            {
                return View(model);

            }
            var houseId = model.Id;
            await houseService.Edit(model);
            return RedirectToAction("Info", "House", new {houseId});

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await houseService.ExistsById(Id) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                return RedirectToAction("Index", "Home");
            }

            await houseService.Delete(Id);

            return RedirectToAction("Index", "Home");
        }
        

        [HttpGet]
        public async Task<IActionResult> Info(int houseId)
        {
            if (await houseService.ExistsById(houseId) == false)
            {
                return RedirectToAction("All", "Member");
            }
            var house = await houseService.GetHouseById(houseId);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (house.FamilyId != familiId)
            {
                return RedirectToAction("Index", "Home");
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
