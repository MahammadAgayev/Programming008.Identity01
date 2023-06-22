using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

using Programming008.Identity01.Constants;
using Programming008.Identity01.Domain.Entities;
using Programming008.Identity01.Models;

namespace Programming008.Identity01.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public AccountController(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        [HttpGet]
        public IActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }


        [HttpPost]
        public IActionResult SignIn(SignInModel model, string? returnUrl = null)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }


            //login user
            Account user = _userManager.FindByNameAsync(model.Username).Result;

            if(user is null)
            {
                ModelState.AddModelError("", "Username or password is incorrect");

                return View(model);
            }

            var result = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;

            if (result.Succeeded == false)
            {
                ModelState.AddModelError("", "Username or password is incorrect");

                return View(model);
            }

            return returnUrl == null ? Redirect("/") : Redirect(returnUrl);
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpModel());
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            Account account = new Account
            {
                Username = model.Username,
            };

            IdentityResult result = _userManager.CreateAsync(account, model.Password)
                 .Result;

            if(result.Succeeded == false)
            {
                string errorMessage = this.ExtractErrorMessage(result);

                ModelState.AddModelError("", errorMessage);
                return View(model);
            }

            _userManager.AddToRoleAsync(account, Roles.Driver);

            return RedirectToAction(nameof(AccountController.SignIn));
        }

        [HttpGet]
        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignOut()
        {

            _userManager.Veir



            _signInManager.SignOutAsync()
                .GetAwaiter().GetResult();

            return Redirect("/");
        }


        private string ExtractErrorMessage(IdentityResult result)
        {
            return result.Errors.Select(x => x.Description)
                .FirstOrDefault("Internal Server Error");
        }
    }
}
