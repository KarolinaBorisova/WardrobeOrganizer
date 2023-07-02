using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.User;

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
    }
}
