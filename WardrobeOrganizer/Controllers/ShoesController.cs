using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Controllers
{
    public class ShoesController : BaseController
    {

        private readonly IShoesService shoesService;
        private readonly IMemberService memberService;
        private readonly IFamilyService familyService;
        private readonly IHouseService houseService;
        private readonly IStorageService storageService;
        private readonly UserManager<User> userManager;

        public ShoesController(IShoesService _shoesService,
            IMemberService _memberService,
            IFamilyService _familyService,
            IHouseService _houseService,
            UserManager<User> _userManager,
            IStorageService _storageService)
        {
            this.shoesService = _shoesService;
            this.memberService = _memberService;
            this.familyService = _familyService;
            this.houseService = _houseService;
            this.userManager = _userManager;
            this.shoesService = _shoesService;
        } 

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(int storageId, string category)
        {
            if (await storageService.ExistsById(storageId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid storage";
                return RedirectToAction("Error", "Home");
            }

            string[] shoesCategory = Enum.GetNames(typeof(CategoryShoes));

            if (!shoesCategory.Contains(category))
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid category";
                return RedirectToAction("Error", "Home");
            }

            var storage = await storageService.GetStorageById(storageId);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (storage.House.FamilyId != familiId)
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

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
            if (await storageService.ExistsById(model.StorageId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid storage";
                return RedirectToAction("Error", "Home");
            }
            string[] shoesCategory = Enum.GetNames(typeof(CategoryShoes));

            if (!shoesCategory.Contains(model.Category))
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid category";
                return RedirectToAction("Error", "Home");
            }

            var storage = await storageService.GetStorageById(model.StorageId);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (storage.House.FamilyId != familiId)
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            var storageId = model.StorageId;

            try
            {
                await shoesService.AddShoes(model);
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
            }
            return RedirectToAction("ShoesByCategory", "Shoes", new { storageId, model.Category });
        }

        public async Task<IActionResult> ShoesByCategory(int storageId, string category)
        {
            try
            {
                var model = await shoesService.AllShoesByCategory(storageId, category);

                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
           
        }

        public async Task<IActionResult> All(int storageId)
        {
            //if storageID ....
            try
            {
                var model = await shoesService.AllShoes(storageId);

                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
          
        }

        public async Task<IActionResult> Details(int shoesId)
        {
            if (await shoesService.ExistsById(shoesId) == false)
            {
                TempData[MessageConstant.WarningMessage] = "Can`t find this shoes";
                return RedirectToAction("Error", "Home");
            }

            var shoes = await shoesService.GetShoesDetailsModelById(shoesId);
            var house = await houseService.GetHouseById(shoes.HouseId);

            try
            {
                int familiId = await familyService.GetFamilyId(User.Id());
                var user = await userManager.FindByIdAsync(User.Id());

                if (house.FamilyId != familiId && await userManager.IsInRoleAsync(user, RoleConstants.User))
                {
                    TempData[MessageConstant.ErrorMessage] = "Not allowed";
                    return RedirectToAction("Error", "Home");
                }

                var model = await shoesService.GetShoesDetailsModelById(shoesId);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
          
        }

        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int shoesId)
        {
            if (await shoesService.ExistsById(shoesId) == false)
            {
                return RedirectToAction("Error", "Home");  
            }
            var shoes = await shoesService.GetShoesDetailsModelById(shoesId);

            try
            {
                await shoesService.DeleteById(shoesId);
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
            }
           
            return RedirectToAction(nameof(All), new { shoes.StorageId });

        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int shoesId)
        {
            if (await shoesService.ExistsById(shoesId)==false)
            {
                return RedirectToAction("Error", "Home");
            }
            var shoes = await shoesService.GetShoesEditModelById(shoesId);

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
                return RedirectToAction("Error", "Home");
            }
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }

            try
            {
                await shoesService.Edit(model);
                TempData[MessageConstant.SuccessMessage] = "Shoes edited";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";

            }
            var shoesId = model.Id;
            return RedirectToAction("Details", "Shoes", new { shoesId });

        }

        public async Task<IActionResult> MemberAllShoes(int memberId)
        {
            
            if (await memberService.ExistsById(memberId))
            {
                return RedirectToAction("Error", "Home");
            }

            var member = await memberService.GetMemberById(memberId);
            var familyId = await familyService.GetFamilyId(User.Id());

            if (member.Family.Id != familyId)
            {
                return RedirectToAction("Error", "Home");

            }
            try
            {
                var model = await shoesService.AllShoesByMemberId(memberId);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
           
        }

        public async Task<IActionResult> MemberShoesByCategory(int memberId, string category)
        {
            if (await memberService.ExistsById(memberId))
            {
                return RedirectToAction("Error", "Home");
            }

            string[] shoesCategory = Enum.GetNames(typeof(CategoryShoes));

            if (!shoesCategory.Contains(category))
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid category";
                return RedirectToAction("Error", "Home");
            }

            var member = await memberService.GetMemberById(memberId);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (member.Id != familiId)
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                var model = await shoesService.AllShoesByCategoryAndMemberId(memberId, category);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
           
        }
    }
}
