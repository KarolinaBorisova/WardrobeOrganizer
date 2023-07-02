using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.User;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Models;

namespace WardrobeOrganizer.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly IStorageService storageService;
        private readonly IMemberService memberService;
        private readonly IFamilyService familyService;
        private readonly IHouseService houseService;
        private readonly ILogger logger;

        public HomeController(UserManager<User> _userManager,
            IStorageService _storageService,
           IMemberService _memberService,
           IFamilyService _familyService,
           IHouseService _houseService,
           ILogger<HomeController> _logger)
        {
            userManager = _userManager;
            storageService = _storageService;
            memberService = _memberService;
            familyService = _familyService;
            houseService = _houseService;
            logger= _logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.FindByIdAsync(User.Id());

            if (user != null && await userManager.IsInRoleAsync(user, RoleConstants.Administrator))
            {
                return RedirectToAction("AllUsers", "Admin", new { area = "Admin" });
            }

            int familiId = await familyService.GetFamilyId(User.Id());
            var model = new HomeUserViewModel
            {
                Houses = await houseService.AllHouses(familiId),
                Members = await memberService.AllMembers(familiId),
                Family = await familyService.GetFamilyByUserId(User.Id())
            };

            return View(model);
           
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}