using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
      
            int houdeId = await houseService.AddHouse(model, familiId);
            return RedirectToAction(nameof(Content), new { houdeId });
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
        public async Task<IActionResult> Info(int houseId)
        {
            if (await houseService.ExistsById(houseId) == false)
            {
                return RedirectToAction("All", "Member");
            }
            var house = await houseService.GetHouseById(houseId);

            var model = new InfoHouseViewModel()
            {
                Address = house.Address,
                FamilyId = house.FamilyId,
                Name = house.Name,
                Storages = await storageService.AllStorages(houseId)

            };


            return View(model);
        }

    }
}
