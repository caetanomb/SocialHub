using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialHub.ApplicationServices.Interfaces;
using SocialHub.Infrastructure.IdentityData;
using SocialHub.Models;

namespace SocialHub.Controllers
{    
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public AccountController(SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
            IEmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)            
                return View(model);            

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return View(model);
            }
        }

        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {

            if (!ModelState.IsValid)
                return View(model);

            var applicationUser = new ApplicationUser() {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var resultUserCreation = await _userManager.CreateAsync(applicationUser, model.Password);

            if (resultUserCreation.Succeeded)
            {
                //Call log provider here

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                var emailConfirmationLink =
                    Url.Action("ConfirmEmail", "Account", new { UserId = applicationUser.Id }, Request.Scheme);
                await _emailService.SendEmailNewUserConfirmation(applicationUser.Email, emailConfirmationLink);

                //Sign in user
                var userSignIn = _signInManager.SignInAsync(applicationUser, false);
                //Log info
                return RedirectToLocal(returnUrl);
            }

            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}