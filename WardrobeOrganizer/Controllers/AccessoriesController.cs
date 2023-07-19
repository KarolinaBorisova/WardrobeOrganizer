using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Controllers
{
    public class AccessoriesController : BaseController
    {
        private readonly IAccessoriesService accessoriesService;
        private readonly IFamilyService familyService;
        private readonly IMemberService memberService;
        private readonly IStorageService storageService;
        private readonly IHouseService houseService;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;


        public AccessoriesController(IAccessoriesService _accessoriesService, 
            IFamilyService _familyService, 
            IMemberService _memberService,
            IStorageService _storageService,
            UserManager<User> _userManager,
            IHouseService _houseService,
        IWebHostEnvironment _webHostEnvironment)
        {
            this.accessoriesService = _accessoriesService;
            this.familyService = _familyService;
            this.memberService = _memberService;
            this.storageService = _storageService;
            this.houseService = _houseService;  
            this.webHostEnvironment = _webHostEnvironment;
            this.userManager = _userManager;
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

            if (storage.House.FamilyId != familiId)
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            try
            {
                var model = await accessoriesService.AllAccessories(storageId);
                return View(model); 
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
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

            string[] accessoriesCategory = Enum.GetNames(typeof(CategoryAccessories));

            if (!accessoriesCategory.Contains(category))
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid category";
                return RedirectToAction("Error", "Home");
            }

            var storage = await storageService.GetStorageById(storageId);
            int familyId = await familyService.GetFamilyId(User.Id());

            if (storage.House.FamilyId != familyId)
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            var model = new AddAccessoriesViewModel()
            {
                StorageId = storageId,
                Category = category,
                Members = await memberService.AllMembersBasic(familyId)
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(AddAccessoriesViewModel model)
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
            string[] accessoriesCategory = Enum.GetNames(typeof(CategoryAccessories));

            if (!accessoriesCategory.Contains(model.Category))
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
                await accessoriesService.AddAccessories(model, rootPath);
            }
            catch (Exception e)
            {

                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
            }

            return RedirectToAction("AccessoriesByCategory", "Accessories", new { storageId, model.Category });

        }

        [HttpGet]
        public async Task<IActionResult> AccessoriesByCategory(int storageId, string category)
        {
            if (await storageService.ExistsById(storageId) == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid storage";
                return RedirectToAction("Error", "Home");
            }
            string[] accessoriesCategory = Enum.GetNames(typeof(CategoryAccessories));

            if (!accessoriesCategory.Contains(category))
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
            try
            {
                var model = await accessoriesService.AllAccessoriesByCategory(storageId, category);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
           
        }

        public async Task<IActionResult> Details(int accessoriesId)
        {
            if (await accessoriesService.ExistsById(accessoriesId) == false)
            {
                TempData[MessageConstant.WarningMessage] = "Can`t find this shoes";
                return RedirectToAction("Error", "Home");
            }

            var accessories = await accessoriesService.GetAccessoriesDetailsModelById(accessoriesId);
            var house = await houseService.GetHouseById(accessories.HouseId);

            int familiId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (house.FamilyId != familiId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            try
            {
                var model = await accessoriesService.GetAccessoriesDetailsModelById(accessoriesId);
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
          
        }

        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int accessoriesId)
        {
            if (await accessoriesService.ExistsById(accessoriesId) == false)
            {
                ModelState.AddModelError("", "Accessorie does not exist");
                return RedirectToAction("Home", "Error");
            }
            var accessorie = await accessoriesService.GetAccessoriesDetailsModelById(accessoriesId);
            var house = await houseService.GetHouseById(accessorie.HouseId);

            int familyId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (house.FamilyId != familyId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
          
            try
            {
                await accessoriesService.DeleteById(accessoriesId);
                TempData[MessageConstant.ErrorMessage] = "Accessorie was deleted";         
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
               
            }

            return RedirectToAction(nameof(All), new { accessorie.StorageId });
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int accessoriesId)
        {
            if (await accessoriesService.ExistsById(accessoriesId) == false)
            {
                ModelState.AddModelError("", "Accessorie does not exist");
                return RedirectToAction("Home", "Error");
            }
            var accessorise = await accessoriesService.GetAccessoriesDetailsModelById(accessoriesId);
            var house = await houseService.GetHouseById(accessorise.HouseId);

            int familyId = await familyService.GetFamilyId(User.Id());
            var user = await userManager.FindByIdAsync(User.Id());

            if (house.FamilyId != familyId && await userManager.IsInRoleAsync(user, RoleConstants.User))
            {
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            var model = new EditAccessoriesViewModel()
            {
                Id = accessoriesId,
                Name = accessorise.Name,
                Description = accessorise.Description,
                SizeAge = accessorise.SizeAge,
                Color = accessorise.Color,
                MemberId = accessorise.MemberId,
                Members = await memberService.AllMembersBasic(familyId),
            };

            return View(model);
        }

        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(EditAccessoriesViewModel model)
        {
            if (await accessoriesService.ExistsById(model.Id)== false)
            {
                ModelState.AddModelError("", "Accessorie does not exist");
                return RedirectToAction("Home", "Error");
            }
            if (ModelState.IsValid == false)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }
            var accessorise = await accessoriesService.GetAccessoriesDetailsModelById(model.Id);
            var house = await houseService.GetHouseById(accessorise.HouseId);

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
                await accessoriesService.Edit(model, rootPath);
                TempData[MessageConstant.SuccessMessage] = "Accessorie edited";
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";

            }
            var accessoriesId = model.Id;
            return RedirectToAction("Details", "Accessories", new { accessoriesId });
        }

        public async Task<IActionResult> MemberAllAccessories(int memberId)
        {
            if (await memberService.ExistsById(memberId) == false)
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
                var model = await accessoriesService.AllAccessoriesByMemberId(memberId);
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Home", "Error");
            }
           
        }

        public async Task<IActionResult> MemberAccessoriesByCategory(int memberId, string category)
        {
            if (await memberService.ExistsById(memberId) == false)
            {
                return RedirectToAction("Error", "Home");
            }

            string[] accessoriesCategory = Enum.GetNames(typeof(CategoryAccessories));

            if (!accessoriesCategory.Contains(category))
            {
                TempData[MessageConstant.ErrorMessage] = "Not valid category";
                return RedirectToAction("Error", "Home");
            }

            var member = await memberService.GetMemberById(memberId);
            int familiId = await familyService.GetFamilyId(User.Id());

            if (member.Family.Id != familiId)
            {
                TempData[MessageConstant.WarningMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }
            try
            {
                var model = await accessoriesService.AllAccessoriesByCategoryAndMemberId(memberId, category);
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Home", "Error");
            }
          
        }
    }
}
