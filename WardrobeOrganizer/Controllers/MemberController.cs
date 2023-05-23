using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Extensions;
using WardrobeOrganizer.Infrastructure.Data.Enums;

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
        public async Task<IActionResult> Info(int id)
        {
            if(await memberService.ExistsById(id) == false)
            {
                return RedirectToAction("All", "Member");
            }

            var model = await memberService.GetMemberById(id);
            
       
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await memberService.ExistsById(id) ==false)
            {
                return RedirectToAction(nameof(All));
            }
            var member = await memberService.GetMemberById(id);
            var model = new InfoMemberViewModel()
            {
                Id = id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                ImgUrl = member.ImgUrl,
                Birthdate = member.Birthdate,
                Gender = member.Gender,
                ShoeSizeEu = member.ShoeSizeEu,
                FootLengthCm = member.FootLengthCm,
                ClothesSize = member.ClothesSize,
                UserHeight = member.UserHeight
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InfoMemberViewModel model)
        {
            if (await memberService.ExistsById(model.Id) == false)
            {
                ModelState.AddModelError("", "Member does not exist");
                return View();
            }
            if (ModelState.IsValid == false)
            {
                return View(model);

            }

            await memberService.Edit(model.Id, model);
            return RedirectToAction("Info", "Member", new { model.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("All", "Member");
        }
    }
}
