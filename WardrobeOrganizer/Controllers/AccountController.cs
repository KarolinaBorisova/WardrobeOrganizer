using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Models;

namespace WardrobeOrganizer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager; 

        public AccountController(
            UserManager<User> _userManager
            ,SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            this.signInManager = _signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

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

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var model = new RegisterViewModel();
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
