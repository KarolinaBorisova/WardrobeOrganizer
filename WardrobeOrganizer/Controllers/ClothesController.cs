using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Controllers
{
    public class ClothesController : BaseController
    {
        private readonly IClothesService clothesService;
        private readonly IFamilyService familyService;
        private readonly IMemberService memberService;
        private readonly IStorageService storageService;
        private readonly IHouseService houseService;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ClothesController(IClothesService _clothesService,
        IFamilyService _familyService,
        IMemberService _memberService,
        IStorageService _storageService,
        IHouseService _houseService,
        UserManager<User> _userManager,
         IWebHostEnvironment _webHostEnvironment)
        {
            this.clothesService = _clothesService;
            this.familyService = _familyService;
            this.memberService = _memberService;
            this.storageService = _storageService;
            this.houseService = _houseService;
            this.userManager = _userManager;
            this.webHostEnvironment = _webHostEnvironment;
        }

        public async Task<IActionResult> All(int storageId) 
        {
            if (await storageService.ExistsById(storageId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid storage";
                return RedirectToAction("Error", "Home");
            }

            var storage = await storageService.GetStorageById(storageId);
            int familiId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (storage.House.FamilyId != familiId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            try
            {
                var model = await clothesService.AllClothes(storageId);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
            
        }

        public async Task<IActionResult> ClothesByCategory(int storageId, string category)
        {
            if (await storageService.ExistsById(storageId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid storage";
                return RedirectToAction("Error", "Home");
            }
            string[] clothesCategory = Enum.GetNames(typeof(CategoryClothes));

            if (!clothesCategory.Contains(category))
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid category";
                return RedirectToAction("Error", "Home");
            }

            var storage = await storageService.GetStorageById(storageId);
            int familiId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (storage.House.FamilyId != familiId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            try
            {
                var model = await clothesService.AllClothesByCategory(storageId, category);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Home", "Error");
            }
           
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
            string[] clothesCategory = Enum.GetNames(typeof(CategoryClothes));

            if (!clothesCategory.Contains(category))
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
            string[] clothesCategory = Enum.GetNames(typeof(CategoryClothes));

            if (!clothesCategory.Contains(model.Category))
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
            var rootPath = this.webHostEnvironment.WebRootPath;

            try
            {
                int id = await clothesService.AddClothes(model, rootPath);
                
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                
            }
            return RedirectToAction("ClothesByCategory", "Clothes", new { storageId, model.Category });
        }

        public async Task<IActionResult> Details(int clothingId)
        {
            if (await clothesService.ExistsById(clothingId) == false)
            {
                TempData[MessageConstant.WarningMessage] = "Can`t find this clothes";
                return RedirectToAction("Error", "Home");
            }

            var clothe = await clothesService.GetClothesDetailsModelById(clothingId);
            var house = await houseService.GetHouseById(clothe.HouseId);

            try
            {
                int familiId = await familyService.GetFamilyId(User.Id());
                var user = await userManager.FindByIdAsync(User.Id());

                 if (house.FamilyId != familiId && await userManager.IsInRoleAsync(user, RoleConstants.User))
                 {
                 TempData[MessageConstant.ErrorMessage] = "Not allowed";
                  return RedirectToAction("Error", "Home");
                 }

                 var model = await clothesService.GetClothesDetailsModelById(clothingId);
                 return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
           
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int clothingId)
        {
            if (await clothesService.ExistsById(clothingId) == false)
            {
                TempData[MessageConstant.WarningMessage] = "Can`t find this clothes";
                return RedirectToAction("Error", "Home");
            }
            var clothing = await clothesService.GetClothesDetailsModelById(clothingId);
            var house = await houseService.GetHouseById(clothing.HouseId);

            int familyId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (house.FamilyId != familyId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            var model = new EditClothesViewModel()
            {
               Id= clothingId,
               Size =  clothing.Size,
               SizeHeight = clothing.SizeHeight,
               Color = clothing.Color,
               Description = clothing.Description,
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
                ModelState.AddModelError("", "Clothing does not exist");
                return View();
            }
            if (ModelState.IsValid == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong";
                return View(model);

            }
            var clothing = await clothesService.GetClothesDetailsModelById(model.Id);
            var house = await houseService.GetHouseById(clothing.HouseId);

            int familyId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (house.FamilyId != familyId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            var rootPath = this.webHostEnvironment.WebRootPath;

            try
            {
                await clothesService.Edit(model, rootPath);
                TempData[MessageConstant.SuccessMessage] = "Clothing edited";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong";
            }
            var clothingId = model.Id;
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
            var house = await houseService.GetHouseById(clothing.HouseId);

            int familyId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (house.FamilyId != familyId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                await clothesService.DeleteById(clothingId);
            }
            catch (Exception)
            {

                TempData[MessageConstant.ErrorMessage] = "Something went wrong";
            }
           
            return RedirectToAction(nameof(All), new {clothing.StorageId});
        }

        public async Task<IActionResult> MemberAllClothes(int memberId)
        {
            if (await memberService.ExistsById(memberId) == false)
            {

                TempData[MessageConstant.WarningMessage] = "Can`t find this clothes";
                return RedirectToAction("Error", "Home");

            }

            var member = await memberService.GetMemberById(memberId);
            var familyId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (member.Family.Id != familyId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {

                TempData[MessageConstant.WarningMessage] = "Can`t find this clothes";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                var model = await clothesService.AllClothesByMemberId(memberId);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
           
        }

        public async Task<IActionResult> MemberClothesByCategory(int memberId, string category)
        {
            if (await memberService.ExistsById(memberId) == false)
            {

                TempData[MessageConstant.WarningMessage] = "Can`t find this clothes";
                return RedirectToAction("Error", "Home");

            }
            string[] clothesCategory = Enum.GetNames(typeof(CategoryClothes));

            if (!clothesCategory.Contains(category))
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid category";
                return RedirectToAction("Error", "Home");
            }
            var member = await memberService.GetMemberById(memberId);
            int familiId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (member.Family.Id != familiId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            try
            {
                var model = await clothesService.AllClothesByCategoryAndMemberId(memberId, category);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
          
        }
    }
} 
