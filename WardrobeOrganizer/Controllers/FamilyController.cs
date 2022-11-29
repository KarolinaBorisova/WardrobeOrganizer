using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Storage;
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
        public IActionResult Add()
        { 
            var model = new FamilyViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FamilyViewModel family)
        {
            if (!ModelState.IsValid)
            { 
                return View(family);
            }

            await familyService.Create(family, User.Id());

            return RedirectToAction("Index", "Home");
        }

    }
}
