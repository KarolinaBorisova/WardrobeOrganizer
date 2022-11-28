using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Extensions;

namespace WardrobeOrganizer.Controllers
{
   
    public class MemberController : Controller
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService _memberService)
        {
            this.memberService = _memberService;
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
            await  memberService.AddMember(model);
            TempData[MessageConstant.SuccessMessage] = "Member added";
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Become()
        {
            var userId = User.Id();

            if (await memberService.ExistsById(userId))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already a member of this family";
                return RedirectToAction("Index", "Home");
            }

           await memberService.Create(userId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Home()
        {
            var model = new HomeMemberViewModel()
            { FirstName= "test",
            LastName = "test2",
            Storages = new List<AllStoragesViewModel>()
            };
            return View(model);
        }
    }
}
