using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.User;
using WardrobeOrganizer.Core.Services;

namespace WardrobeOrganizer.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IUserService userService;

        public AdminController(IUserService _userService)
        {
            this.userService = _userService;
                
        }
        public async Task<IActionResult> AllUsers()
        {
            var model = await userService.AllUsers();
            return View(model);
        }

        public async Task<IActionResult> InActive(string id)
        {
            if (await userService.ExistsById(id) == false)
            {
                ModelState.AddModelError("", "User does not exist");

                return RedirectToAction("Index", "Home");
            }

            try
            {
                await userService.InActive(id);
                TempData[MessageConstant.ErrorMessage] = "User is inactive";
            }
            catch (Exception)
            {
               // logger.LogInformation("Can not delete member with id {0}", Id);

            }


            return RedirectToAction("AllUsers", "Admin", new { area = "Admin" });
        }

        public async Task<IActionResult> Active(string id)
        {
            if (await userService.ExistsById(id) == false)
            {
                ModelState.AddModelError("", "User does not exist");

                return RedirectToAction("Index", "Home");
            }

            try
            {
                await userService.Active(id);
                TempData[MessageConstant.SuccessMessage] = "User is active";
            }
            catch (Exception)
            {
                // logger.LogInformation("Can not delete member with id {0}", Id);

            }


            return RedirectToAction("AllUsers", "Admin", new { area = "Admin" });
        }
    }
}
