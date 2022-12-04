using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models;
using WardrobeOrganizer.Core.Models.Family;
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

            int id =  await  memberService.AddMember(model);
            TempData[MessageConstant.SuccessMessage] = "Member added";
            return RedirectToAction("Home", "Member", new { id} );
        }


        [HttpGet]
        public IActionResult Home()
        {
            var model  = new HomeMemberViewModel()
            { FirstName= "test",
            LastName = "test2",
            MineStorage = new StoragesViewModel(),
            Family = new FamilyViewModel()
            };
            return View(model);
        }
    }
}
