using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Clothes;
using WardrobeOrganizer.Core.Models.Outerwear;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    public class OuterwearController : Controller
    {

        private readonly IOuterwearService outerwearService;

        public OuterwearController(IOuterwearService outerwearService)
        {
            this.outerwearService = outerwearService;
        }

        public async Task<IActionResult> All(int storageId)
        {
            var model = await outerwearService.AllOutwear(storageId);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int storageId, string category)
        {
            var model = new AddOuterwearViewModel()
            {
                StorageId=  storageId,
                Category=category
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOuterwearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }

            var storageId = model.StorageId;
            int id = await outerwearService.AddOuterWear(model);
            return RedirectToAction("OuterwearByCategory", "Outerwear", new { storageId, model.Category });

        }

        [HttpGet]
        public async Task<IActionResult> OuterwearByCategory(int storageId, string category)
        {
            var model = await outerwearService.AllOuterwearByCategory(storageId, category);
            return View(model);
        }

        public async Task<IActionResult> Details(int outerwearId)
        {
            var model = await outerwearService.GetOuterwearById(outerwearId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int outerwearId)
        {
            if (await outerwearService.ExistsById(outerwearId) == false)
            {
                ModelState.AddModelError("", "Outerwear does not exist");
                return RedirectToAction("Outerwear", "All"); //Error page
            }
            var outerwear = await outerwearService.GetOuterwearById(outerwearId);
            await outerwearService.DeleteById(outerwearId);
            return RedirectToAction(nameof(All), new { outerwear.StorageId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int outerwearId)
        {
            if (await outerwearService.ExistsById(outerwearId) == false)
            {
               // logger.LogInformation("Clothing with id {0} not exist", outerwearId);
                return RedirectToAction(nameof(All));
            }
            var clothing = await outerwearService.GetOuterwearById(outerwearId);

            var model = new DetailsOuterwearViewModel()
            {
                Id = outerwearId,
                Size = clothing.Size,
                SizeHeight = clothing.SizeHeight,
                StorageId = clothing.StorageId,
                Category = clothing.Category,
                Color = clothing.Color,
                Description = clothing.Description,
                ImgUrl = clothing.ImgUrl,
                Name = clothing.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DetailsOuterwearViewModel model)
        {
            if (await outerwearService.ExistsById(model.Id) == false)
            {
                //logger.LogInformation("Clothing with id {0} not exist", model.Id);
                ModelState.AddModelError("", "Outerwear does not exist");
                return View();
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
               // logger.LogInformation("Failed to edit member with id {0}", model.Id);

            }
            var outerwearId = model.Id;
            //  return RedirectToAction("Info", "Member", new { model.Id });
            return RedirectToAction("Details", "Outerwear", new { outerwearId });
        }

        public async Task<IActionResult> MemberAllOuterwear(int memberId)
        {
            var model = await outerwearService.AllOuterwearByMemberId(memberId);
            return View(model);
        }

        public async Task<IActionResult> MemberOuterwearByCategory(int memberId, string category)
        {
            var model = await outerwearService.AllOuterwearByCategoryAndMemberId(memberId, category);
            return View(model);
        }
    }
}
