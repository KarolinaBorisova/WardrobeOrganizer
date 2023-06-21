﻿using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IAccessoriesService accessoriesService;

        public AccessoriesController(IAccessoriesService _accessoriesService)
        {
            this.accessoriesService = _accessoriesService;
        }

        public async Task<IActionResult> All(int storageId)
        {
            var model = await accessoriesService.AllAccessories(storageId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int storageId, string category)
        {
            var model = new AddAccessoriesViewModel()
            {
                StorageId = storageId,
                Category = category
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAccessoriesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }

            var storageId = model.StorageId;
            int id = await accessoriesService.AddAccessories(model);
            return RedirectToAction("AccessoriesByCategory", "Accessories", new { storageId, model.Category });

        }

        [HttpGet]
        public async Task<IActionResult> AccessoriesByCategory(int storageId, string category)
        {
            var model = await accessoriesService.AllAccessoriesByCategory(storageId, category);
            return View(model);
        }

        public async Task<IActionResult> Details(int accessoriesId)
        {
            var model = await accessoriesService.GetAccessoriesById(accessoriesId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int accessoriesId)
        {
            if (await accessoriesService.ExistsById(accessoriesId) == false)
            {
                ModelState.AddModelError("", "Accessorie does not exist");
                return RedirectToAction("Accessories", "All");
            }
            var accessorie = await accessoriesService.GetAccessoriesById(accessoriesId);
            await accessoriesService.DeleteById(accessoriesId);
            return RedirectToAction(nameof(All), new { accessorie.StorageId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int accessoriesId)
        {
            if (await accessoriesService.ExistsById(accessoriesId) == false)
            {
                ModelState.AddModelError("", "Accessorie does not exist");
                return RedirectToAction("Accessories", "All");
            }
            var accessorise = await accessoriesService.GetAccessoriesById(accessoriesId);

            if (accessorise == null)
            {

            }
            var model = new DetailsAccessoriesViewModel()
            {
                Id = accessoriesId,
                Name = accessorise.Name,
                Description = accessorise.Description,
                SizeAge = accessorise.SizeAge,
                Category = accessorise.Category,
                Color = accessorise.Color,
                StorageId = accessorise.StorageId,
                ImgUrl = accessorise.ImgUrl
            };

            return View(model);
        }

        public async Task<IActionResult> Edit(DetailsAccessoriesViewModel model)
        {
            if (await accessoriesService.ExistsById(model.Id)== false)
            {

            }
            if (ModelState.IsValid == false)
            {

            }


            try
            {
                await accessoriesService.Edit(model);
                TempData[MessageConstant.SuccessMessage] = "Accessorie edited";
            }
            catch (Exception)
            {
                // logger.LogInformation("Failed to edit member with id {0}", model.Id);

            }
            var accessoriesId = model.Id;
            //  return RedirectToAction("Info", "Member", new { model.Id });
            return RedirectToAction("Details", "Accessories", new { accessoriesId });
        }

        public async Task<IActionResult> MemberAllAccessories(int memberId)
        {
            var model = await accessoriesService.AllAccessoriesByMemberId(memberId);
            return View(model);
        }

        public async Task<IActionResult> MemberAccessoriesByCategory(int memberId, string category)
        {
            var model = await accessoriesService.AllAccessoriesByCategoryAndMemberId(memberId, category);
            return View(model);
        }
    }
}
