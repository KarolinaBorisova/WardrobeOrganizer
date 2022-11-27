using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
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
    }
}
