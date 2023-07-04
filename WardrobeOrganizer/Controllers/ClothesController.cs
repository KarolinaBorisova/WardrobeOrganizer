using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    public class ClothesController : BaseController
    {
        private readonly IClothesService clothesService;
        private readonly IFamilyService familyService;
        private readonly IMemberService memberService;
  

        public ClothesController(IClothesService _clothesService,
        IFamilyService _familyService,
        IMemberService _memberService)
        {
            this.clothesService = _clothesService;
            this.familyService = _familyService;
            this.memberService = _memberService;
        }   

        public async Task<IActionResult> All(int storageId) 
        {
             var model = await clothesService.AllClothes(storageId);
            return View(model);
        }

        public async Task<IActionResult> ClothesByCategory(int storageId, string category)
        {

            var model = await clothesService.AllClothesByCategory(storageId, category);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(int storageId, string category)
        {
            var familyId = await familyService.GetFamilyId(User.Id());
            var model = new AddClothesViewModel()
            {
                StorageId = storageId,
                Category = category,
                Members = await memberService.AllMembersBasic(familyId)  
                
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(AddClothesViewModel model)
        {
            if(!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }
            var storageId = model.StorageId;
            int id = await clothesService.AddClothes(model);
            return RedirectToAction("ClothesByCategory", "Clothes", new { storageId , model.Category});
        }

        public async Task<IActionResult> Details(int clothingId)
        {
            var model = await clothesService.GetClothesDetailsModelById(clothingId);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int clothingId)
        {
            if (await clothesService.ExistsById(clothingId) == false)
            {
                //logger.LogInformation("Clothing with id {0} not exist", clothingId);
                return RedirectToAction(nameof(All));
            }
            var clothing = await clothesService.GetClothesEditModelById(clothingId);
            var familyId = await familyService.GetFamilyId(User.Id());

            var model = new EditClothesViewModel()
            {
               Id= clothingId,
               Size =  clothing.Size,
               SizeHeight = clothing.SizeHeight,
               Color = clothing.Color,
               Description = clothing.Description,
               ImgUrl = clothing.ImgUrl,
               Name = clothing.Name,
               Members = await memberService.AllMembersBasic(familyId),
               MemberId = clothing.MemberId
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit( EditClothesViewModel model)
        {
            if (await clothesService.ExistsById(model.Id) == false)
            {
              //  logger.LogInformation("Clothing with id {0} not exist", model.Id);
                ModelState.AddModelError("", "Clothing does not exist");
                return View();
            }
            if (ModelState.IsValid == false)
            {
                return View(model);

            }

            try
            {
                await clothesService.Edit(model);
                TempData[MessageConstant.SuccessMessage] = "Clothing edited";
            }
            catch (Exception)
            {
               // logger.LogInformation("Failed to edit member with id {0}", model.Id);

            }
            var clothingId = model.Id;
            //  return RedirectToAction("Info", "Member", new { model.Id });
            return RedirectToAction("Details", "Clothes", new { clothingId });
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int clothingId)
        {
            if (await clothesService.ExistsById(clothingId) == false)
            {
                ModelState.AddModelError("", "Clothing does not exist");
                return RedirectToAction("Clothes", "All");
            }
            var clothing = await clothesService.GetClothesDetailsModelById(clothingId);
            await clothesService.DeleteById(clothingId);
            return RedirectToAction(nameof(All), new {clothing.StorageId});
        }

        public async Task<IActionResult> MemberAllClothes(int memberId)
        {
            var model = await clothesService.AllClothesByMemberId(memberId);
            return View(model);
        }

        public async Task<IActionResult> MemberClothesByCategory(int memberId, string category)
        {
            var model = await clothesService.AllClothesByCategoryAndMemberId(memberId, category);
            return View(model);
        }
    }
} 
