using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Models.User;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
  
    public class FamilyController : BaseController
    {
        private readonly IFamilyService familyService;
        private readonly IStorageService storageService;
        private readonly IMemberService memberService;
        private readonly IHouseService houseService;
        private readonly ILogger logger;


        public FamilyController(IFamilyService _familyService,
             IStorageService _storageService,
             IMemberService _memberService,
             IHouseService _houseService,
             ILogger<FamilyController> _logger)
        {
            familyService = _familyService;
            storageService = _storageService;
            memberService = _memberService;
            houseService = _houseService;
            logger = _logger;
        }
      
        public async Task<IActionResult> Info(string userId)
        {
            var family = await familyService.GetFamilyByUserId(userId);
            if (family == null)
            {
                TempData[MessageConstant.ErrorMessage] = "This user hasn't added family yet.";
                return RedirectToAction("Add", "Family");
            }
            var model = new InfoFamilyViewModel()
            {
                Id = family.Id,
                Name = family.Name,
                Members = await memberService.AllMembers(family.Id),
                Houses = await houseService.AllHouses(family.Id)
            };
            
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add()
        {
            var userId = User.Id();     

            if (await familyService.HasFamily(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You already add a family";
                return RedirectToAction("Index", "Home");
            }
            var model = new FamilyViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(FamilyViewModel family)
        {
            var userId = User.Id();

            if (await familyService.HasFamily(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already add a family";
                return RedirectToAction("Index", "Home");
            }


            if (!ModelState.IsValid)
            { 
                return View(family);
            }

            try
            {
                await familyService.Create(family, User.Id());
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong";
            }
           

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int id)
        {
            if (await familyService.ExistsById(id) == false)
            {
                return RedirectToAction("Error", "Home");
            }

            var family = await familyService.GetFamilyByUserId(User.Id());
           
            var model = new FamilyViewModel()
            {
                Id = id,
                Name = family.Name,
                UserId = family.UserId
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit( FamilyViewModel model)
        {
            if (await familyService.ExistsById(model.Id) == false)
            {
                ModelState.AddModelError("", "Family does not exist");
                return View();
            }
            if (ModelState.IsValid == false)
            {
                return View(model);

            }
            var userId = User.Id();
            var familyId = model.Id;

            try
            {
                await familyService.Edit(model);
                return RedirectToAction("Info", "Family", new { userId });
            }
            catch (Exception)
            {

                TempData[MessageConstant.ErrorMessage] = "Something went wrong";
                return View(model);          
            }
            
            
            
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("All", "Family");
        }

    }
}
