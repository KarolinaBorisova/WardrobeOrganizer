using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    public class ShoesController : BaseController
    {

        private readonly IShoesService shoesService;
        private readonly IMemberService memberService;
        private readonly IFamilyService familyService;

        public ShoesController(IShoesService _shoesService,
            IMemberService _memberService,
            IFamilyService _familyService)
        {
            this.shoesService = _shoesService;
            this.memberService = _memberService;
            this.familyService = _familyService;
        } 

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(int storageId, string category)
        {
            var familyId = await familyService.GetFamilyId(User.Id());
            var model = new AddShoesViewModel()
            {
                StorageId = storageId,
                Category = category,
                Members = await memberService.AllMembersBasic(familyId)
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(AddShoesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }
            var storageId = model.StorageId;
            int id = await shoesService.AddShoes(model);
            return RedirectToAction("ShoesByCategory", "Shoes", new { storageId, model.Category });
        }

        public async Task<IActionResult> ShoesByCategory(int storageId, string category)
        {
            var model = await shoesService.AllShoesByCategory(storageId, category);

            return View(model);
        }

        public async Task<IActionResult> All(int storageId)
        {
            var model = await shoesService.AllShoes(storageId);

            return View(model);
        }

        public async Task<IActionResult> Details(int shoesId)
        {
            var model = await shoesService.GetShoesDetailsModelById(shoesId);
            return View(model);
        }

        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int shoesId)
        {
            if (await shoesService.ExistsById(shoesId) == false)
            {
                ModelState.AddModelError("", "Shoes does not exist");
                return RedirectToAction("Shoes", "All"); //Error page
            }
            var shoes = await shoesService.GetShoesDetailsModelById(shoesId);
            await shoesService.DeleteById(shoesId);
            return RedirectToAction(nameof(All), new { shoes.StorageId });

        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int shoesId)
        {
            if (await shoesService.ExistsById(shoesId)==false)
            {

            }
            var shoes = await shoesService.GetShoesEditModelById(shoesId);

            if (shoes == null)
            {

            }
            var familyId = await familyService.GetFamilyId(User.Id());
            var model = new EditShoesViewModel()
            {
                Id=shoes.Id,
                Name = shoes.Name,
                Description = shoes.Description,
                SizeEu = shoes.SizeEu,
                Centimetres = shoes.Centimetres,
                Color = shoes.Color,
                ImgUrl = shoes.ImgUrl,
                MemberId = shoes.MemberId,
                Members = await memberService.AllMembersBasic(familyId)

            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(EditShoesViewModel model)
        {
            if (await shoesService.ExistsById(model.Id) == false)
            {

            }
            if (!ModelState.IsValid)
            {

            }

            try
            {
                await shoesService.Edit(model);
                TempData[MessageConstant.SuccessMessage] = "Shoes edited";
            }
            catch (Exception)
            {
                // logger.LogInformation("Failed to edit member with id {0}", model.Id);

            }
            var shoesId = model.Id;
            //  return RedirectToAction("Info", "Member", new { model.Id });
            return RedirectToAction("Details", "Shoes", new { shoesId });

        }

        public async Task<IActionResult> MemberAllShoes(int memberId)
        {
            var model = await shoesService.AllShoesByMemberId(memberId);
            return View(model);
        }

        public async Task<IActionResult> MemberShoesByCategory(int memberId, string category)
        {
            var model = await shoesService.AllShoesByCategoryAndMemberId(memberId, category);
            return View(model);
        }
    }
}
