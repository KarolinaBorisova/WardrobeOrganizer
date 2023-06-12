using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Shoes;
using WardrobeOrganizer.Core.Services;

namespace WardrobeOrganizer.Controllers
{
    public class ShoesController : Controller
    {

        private readonly IShoesService shoesService;

        public ShoesController(IShoesService _shoesService)
        {
            this.shoesService = _shoesService;
        } 

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add(int storageId)
        {
            var model = new AddShoesViewModel()
            {
                StorageId = storageId
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
            return RedirectToAction("Storage", "Info", new { storageId });
        }

    }
}
