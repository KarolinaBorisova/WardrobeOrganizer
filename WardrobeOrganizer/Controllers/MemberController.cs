using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Controllers
{
    public class MemberController : BaseController
    {
        private readonly IMemberService memberService;
        private readonly IFamilyService familyService;
        private readonly ILogger logger;
        private readonly UserManager<User> userManager;

        public MemberController(IMemberService _memberService,
            IFamilyService _familyService,
            ILogger<MemberController> _logger,
            UserManager<User> _userManager)
        {
            this.memberService = _memberService;
            this.familyService = _familyService;
            this.logger = _logger;
            this.userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            int familiId = await familyService.GetFamilyId(User.Id());
            var model = await memberService.AllMembers(familiId);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public IActionResult Add()
        {
            var model = new AddMemberViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Add(AddMemberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
                return View(model);
            }

            int memberId;

            try
            {
                int familiId = await familyService.GetFamilyId(User.Id());
                memberId = await memberService.AddMember(model, familiId);
                TempData[MessageConstant.SuccessMessage] = "Member added";
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Add), ex);
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";
            }   
           
            return RedirectToAction("All", "Member");
        }


        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            if(await memberService.ExistsById(id) == false )
            {
                logger.LogInformation("Member with id {0} not exist", id);
                 TempData[MessageConstant.ErrorMessage] = "Can`t find this member";
                return RedirectToAction("Error", "Home");
            }

            InfoMemberViewModel model;
            int familyId;
           
            try
            {
                model = await memberService.GetMemberById(id);
                familyId = await familyService.GetFamilyId(User.Id());
                
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Info), ex);
                return RedirectToAction("Error", "Home");
            }
           
            var user = await userManager.FindByIdAsync(User.Id());

            if (model.Family.Id != familyId && await userManager.IsInRoleAsync(user,RoleConstants.User))
            {
                logger.LogInformation("Family with id {0} attempted to open other family house", familyId);
                return RedirectToAction("Error", "Home");
            }
       
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(int id)
        {
            if (await memberService.ExistsById(id) ==false)
            {
                logger.LogInformation("Member with id {0} not exist", id);
                TempData[MessageConstant.ErrorMessage] = "Can`t find member with this id";
                return RedirectToAction("Error", "Home");
            }

            var member = await memberService.GetMemberById(id);
            var familyId = await familyService.GetFamilyId(User.Id());

            if (member.Family.Id != familyId )
            {
                logger.LogInformation("Family with id {0} attempted to edit other family house", familyId);
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

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
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Edit(InfoMemberViewModel model)
        {
            if (await memberService.ExistsById(model.Id) == false)
            {
                logger.LogInformation("Member with id {0} not exist", model.Id);
                ModelState.AddModelError("", "Member does not exist");
                return View();
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var member = await memberService.GetMemberById(model.Id);
            var familyId = await familyService.GetFamilyId(User.Id());

            if (member.Family.Id != familyId)
            {
                logger.LogInformation("Family with id {0} attempted to edit other family house", familyId);
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            try
            {
               
                await memberService.Edit(model);
                TempData[MessageConstant.SuccessMessage] = "Member edited";
            }
            catch (Exception )
            {
                logger.LogInformation("Failed to edit member with id {0}", model.Id);
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";

            }
            
            return RedirectToAction("Info", "Member", new { model.Id });
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.User)]
        public async Task<IActionResult> Delete(int Id)
        {
            if (await memberService.ExistsById(Id) == false)
            {
                logger.LogInformation("Member with id {0} not exist", Id);
                ModelState.AddModelError("", "Member does not exist");

                return RedirectToAction("Error", "Home");
            }

            var member = await memberService.GetMemberById(Id);
            var familyId = await familyService.GetFamilyId(User.Id());

            if (member.Family.Id != familyId)
            {
                logger.LogInformation("Family with id {0} attempted to edit other family house", familyId);
                TempData[MessageConstant.ErrorMessage] = "Not allowed";
                return RedirectToAction("Error", "Home");
            }

            try
            {

                await memberService.Delete(Id);
                TempData[MessageConstant.ErrorMessage] = "Member deleted";
            }
            catch (Exception)
            {
                logger.LogInformation("Can not delete member with id {0}", Id);
                TempData[MessageConstant.ErrorMessage] = "Something went wrong! Try again";

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
