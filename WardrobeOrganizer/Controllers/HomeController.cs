using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.User;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Models;

namespace WardrobeOrganizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStorageService storageService;
        private readonly IMemberService memberService;
        private readonly IFamilyService familyService;

        public HomeController(ILogger<HomeController> logger,
           IStorageService _storageService,
           IMemberService _memberService,
           IFamilyService _familyService)
        {
            _logger = logger;
            storageService = _storageService;
            memberService = _memberService;
            familyService = _familyService;
        }

        public async Task<IActionResult> Index()
        {
            int familiId = await familyService.GetFamilyId(User.Id());
            var model = new HomeUserViewModel
            {
                Storages = await storageService.AllStorages(familiId),
                Members = await memberService.AllMembers(familiId),
                Family = await familyService.GetFamilyByUserId(User.Id())
            };

            return View(model);
           
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}