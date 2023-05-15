﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Models.User;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;

namespace WardrobeOrganizer.Controllers
{
    [Authorize]
    public class FamilyController : Controller
    {
        private readonly IFamilyService familyService;
        private readonly IStorageService storageService;
        private readonly IMemberService memberService;

       
        public FamilyController(IFamilyService _familyService,
             IStorageService _storageService,
             IMemberService _memberService )
        {
            familyService = _familyService;
            storageService = _storageService;
            memberService = _memberService;
        }
      
        public async Task<IActionResult> Info()
        {
            var family = await familyService.GetFamilyByUserId(User.Id());
            var model = new InfoFamilyViewModel()
            {
                Id = family.Id,
                Name = family.Name,
                Members = await memberService.AllMembers(family.Id),
                Storages = await storageService.AllStorages(family.Id)

            };
            
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new FamilyViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FamilyViewModel model)
        {
            return RedirectToAction("Info", "Family", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("All", "Family");
        }

    }
}
