﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Core.Constants;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Models;

namespace WardrobeOrganizer.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
            UserManager<User> _userManager
            ,SignInManager<User> _signInManager
            ,RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            this.signInManager = _signInManager;
            this.roleManager = _roleManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Home/Index");
            }
            var model = new RegisterViewModel();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

        
            var user = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                UserName = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, RoleConstants.User);
            await userManager
                .AddClaimAsync(user,
                new System.Security.Claims.Claim(ClaimTypeConstants.FirstName, user.FirstName ?? user.Email));

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }
            
            foreach(var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Home/Index");
            }
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model); 
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                if (user.IsActive == false)
                {
                    ModelState.AddModelError("", "This account was blocked");
                    return View(model);
                }
               var result = await signInManager.PasswordSignInAsync(user, model.Password, false , false);

                if (result.Succeeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    if (await userManager.IsInRoleAsync(user , "Administrator"))
                    {
                        return RedirectToAction("AllUsers", "Admin", new { area = "Admin" });
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
    }
}
