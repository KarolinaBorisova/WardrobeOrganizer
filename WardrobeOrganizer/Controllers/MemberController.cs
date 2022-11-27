using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Extensions;

namespace WardrobeOrganizer.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService _memberService)
        {
            this.memberService = _memberService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await memberService.ExistsById(User.Id()))
            {
                TempData[MessageConstant.ErrorMessage] = "You are already a member of this family";
                return RedirectToAction("Index", "Home");
            }

            TempData[MessageConstant.SuccessMessage] = "You are already a member of this family";
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public IActionResult Become(BecomeMemberModel model)
        {
           
            return View();
        }
    }
}
