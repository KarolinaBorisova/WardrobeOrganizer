using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Controllers
{
    [Authorize]
    public class StorageController : Controller
    {

        private readonly IStorageService storageService;


        public StorageController(IStorageService _storageService)
        {
            this.storageService = _storageService;
         
        }

        public async Task<IActionResult> All()
        {
            var model = await storageService.AllStorages();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddStorageViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStorageViewModel model)
        {
            int id = 1;
            return RedirectToAction(nameof(Content), new { id });
        }

        public async Task<IActionResult> Content(int id)
        {
            var model = new ContentStorageViewModel();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new EditStorageViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditStorageViewModel model)
        {
           return RedirectToAction(nameof (Content), new { id, model });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction(nameof(All));
        }



    }
}
