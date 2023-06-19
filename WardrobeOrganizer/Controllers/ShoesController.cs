using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    public class ShoesController : Controller
    {

        private readonly IShoesService shoesService;

        public ShoesController(IShoesService _shoesService)
        {
            this.shoesService = _shoesService;
        } 

        [HttpGet]
        public IActionResult Add(int storageId, string category)
        {
            var model = new AddShoesViewModel()
            {
                StorageId = storageId,
                Category = category
            };
            return View(model);
        }

        [HttpPost]
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
            var model = await shoesService.GetShoesById(shoesId);
            return View(model);
        }

        public async Task<IActionResult> Delete(int shoesId)
        {
            if (await shoesService.ExistsById(shoesId) == false)
            {
                ModelState.AddModelError("", "Shoes does not exist");
                return RedirectToAction("Shoes", "All"); //Error page
            }
            var shoes = await shoesService.GetShoesById(shoesId);
            await shoesService.DeleteById(shoesId);
            return RedirectToAction(nameof(All), new { shoes.StorageId });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int shoesId)
        {
            if (await shoesService.ExistsById(shoesId)==false)
            {

            }
            var shoes = await shoesService.GetShoesById(shoesId);

            if (shoes == null)
            {

            }
            var model = new DetailsShoesViewModel()
            {
                Id = shoes.Id,
                Name = shoes.Name,
                Description = shoes.Description,
                SizeEu = shoes.SizeEu,
                Centimetres = shoes.Centimetres,
                StorageId = shoes.StorageId,
                Category = shoes.Category,
                Color = shoes.Color,
                ImgUrl = shoes.ImgUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DetailsShoesViewModel model)
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
    }
}
