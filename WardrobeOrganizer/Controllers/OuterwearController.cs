using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    public class OuterwearController : BaseController
    {

        private readonly IOuterwearService outerwearService;
        private readonly IFamilyService familyService;
        private readonly IMemberService memberService;

        public OuterwearController(IOuterwearService _outerwearService,
            IFamilyService _familyService,
            IMemberService _memberService)
        {
            this.outerwearService = _outerwearService;
            this.familyService = _familyService;
            this.memberService = _memberService;
        }

        public async Task<IActionResult> All(int storageId)
        {
            var model = await outerwearService.AllOutwear(storageId);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(int storageId, string category)
        {
            var familyId = await familyService.GetFamilyId(User.Id());
            var model = new AddOuterwearViewModel()
            {
                StorageId=  storageId,
                Category=category,
                Members = await memberService.AllMembersBasic(familyId)
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(AddOuterwearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }

            var storageId = model.StorageId;

            try
            {
                int id = await outerwearService.AddOuterWear(model);
            }
            catch (Exception)
            {

                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
            }
            
            return RedirectToAction("OuterwearByCategory", "Outerwear", new { storageId, model.Category });
        }

        [HttpGet]
        public async Task<IActionResult> OuterwearByCategory(int storageId, string category)
        {
            try
            {
                var model = await outerwearService.AllOuterwearByCategory(storageId, category);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
           
        }

        public async Task<IActionResult> Details(int outerwearId)
        {
            try
            {
                var model = await outerwearService.GetOuterwearDetailsModelById(outerwearId);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
          
        }

        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int outerwearId)
        {
            if (await outerwearService.ExistsById(outerwearId) == false)
            {
                ModelState.AddModelError("", "Outerwear does not exist");
                return RedirectToAction("Outerwear", "All"); 
            }

            var outerwear = await outerwearService.GetOuterwearDetailsModelById(outerwearId);
            try
            {
                await outerwearService.DeleteById(outerwearId);
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
            }
            return RedirectToAction(nameof(All), new { outerwear.StorageId });
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int outerwearId)
        {
            if (await outerwearService.ExistsById(outerwearId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Can`t find this outerwear";
                return RedirectToAction(nameof(All));
            }
            var outerwear = await outerwearService.GetOuterwearEditModelById(outerwearId);
            var familyId = await familyService.GetFamilyId(User.Id());

            var model = new EditOuterwearViewModel()
            {
                Id = outerwearId,
                Size = outerwear.Size,
                SizeHeight = outerwear.SizeHeight,
                Color = outerwear.Color,
                Description = outerwear.Description,
                ImgUrl = outerwear.ImgUrl,
                Name = outerwear.Name,
                MemberId = outerwear.MemberId,
                Members = await memberService.AllMembersBasic(familyId)
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(EditOuterwearViewModel model)
        {
            if (await outerwearService.ExistsById(model.Id) == false)
            {
                //logger.LogInformation("Clothing with id {0} not exist", model.Id);
                ModelState.AddModelError("", "Outerwear does not exist");
                return RedirectToAction(nameof(All));
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            try
            {
                await outerwearService.Edit(model);
                TempData[MessageConstant.SuccessMessage] = "Outerwear edited";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";

            }
            var outerwearId = model.Id;
            return RedirectToAction("Details", "Outerwear", new { outerwearId });
        }

        public async Task<IActionResult> MemberAllOuterwear(int memberId)
        {
            try
            {
                var model = await outerwearService.AllOuterwearByMemberId(memberId);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }

        public async Task<IActionResult> MemberOuterwearByCategory(int memberId, string category)
        {
            try
            {
                var model = await outerwearService.AllOuterwearByCategoryAndMemberId(memberId, category);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }
    }
}
