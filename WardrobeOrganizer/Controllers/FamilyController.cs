using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;

namespace WardrobeOrganizer.Controllers
{
    [Authorize]
    public class FamilyController : Controller
    {
        private readonly IFamilyService familyService;

       
        public FamilyController(IFamilyService _familyService)
        {
            familyService = _familyService;
        }
      
        public async Task<IActionResult> Info(int id)
        {
            var model = new InfoFamilyViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var userId = User.Id();     

            if (await familyService.HasFamily(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already add a family";
                return RedirectToAction("Index", "Home");
            }
            var model = new FamilyViewModel();
            return View(model);
        }

        [HttpPost]
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

            await familyService.Create(family, User.Id());

            return RedirectToAction("Index", "Home");
        }

    }
}
