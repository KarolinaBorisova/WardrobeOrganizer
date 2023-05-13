using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;

namespace WardrobeOrganizer.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberService memberService;
        private readonly IFamilyService familyService;

        public MemberController(IMemberService _memberService,
            IFamilyService _familyService)
        {
            this.memberService = _memberService;
            this.familyService = _familyService;
        }

        [HttpGet]
        public async Task<IActionResult> All(int id)
        {
              TempData[MessageConstant.SuccessMessage] = "Member added";
            int familiId = await familyService.GetFamilyId(User.Id());
            var model = await memberService.AllMembers(familiId);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddMemberViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMemberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }
            int familiId = await familyService.GetFamilyId(User.Id());

            int id =  await  memberService.AddMember(model,familiId);
            return RedirectToAction("All", "Member", new {id} );
        }


        [HttpGet]
        public IActionResult Info(int id)
        {
            var model  = new InfoMemberViewModel()
            { FirstName= "test",
            LastName = "test2",
            MineStorage = new AllStoragesViewModel(),
            Family = new FamilyViewModel()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new AddMemberViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddMemberViewModel model)
        {
            return RedirectToAction("Info", "Member", new { id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("All", "Member");
        }
    }
}
