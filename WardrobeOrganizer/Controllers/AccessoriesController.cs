using Microsoft.AspNetCore.Authorization;
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

namespace WardrobeOrganizer.Controllers
{
    public class AccessoriesController : BaseController
    {
        private readonly IAccessoriesService accessoriesService;
        private readonly IFamilyService familyService;
        private readonly IMemberService memberService;


        public AccessoriesController(IAccessoriesService _accessoriesService, 
            IFamilyService _familyService, 
            IMemberService _memberService)
        {
            this.accessoriesService = _accessoriesService;
            this.familyService = _familyService;
            this.memberService = _memberService;
        }

        public async Task<IActionResult> All(int storageId)
        {         
            var model = await accessoriesService.AllAccessories(storageId);
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(int storageId, string category)
        {
            var familyId = await familyService.GetFamilyId(User.Id());
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

            var storageId = model.StorageId;

            try
            {
                await accessoriesService.AddAccessories(model);
            }
            catch (Exception e)
            {

                this.ModelState.AddModelError(string.Empty, e.Message);
                return this.View(model);
            }

            return RedirectToAction("AccessoriesByCategory", "Accessories", new { storageId, model.Category });

        }

        [HttpGet]
        public async Task<IActionResult> AccessoriesByCategory(int storageId, string category)
        {
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
            var accessorise = await accessoriesService.GetAccessoriesEditModelById(accessoriesId);

            var familyId = await familyService.GetFamilyId(User.Id());
            var model = new EditAccessoriesViewModel()
            {
                Id = accessoriesId,
                Name = accessorise.Name,
                Description = accessorise.Description,
                SizeAge = accessorise.SizeAge,
                Color = accessorise.Color,
                ImgUrl = accessorise.ImgUrl,
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


            try
            {
                await accessoriesService.Edit(model);
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
