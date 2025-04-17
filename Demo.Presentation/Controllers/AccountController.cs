using Microsoft.AspNetCore.Mvc;
using Demo.Presentation.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Demo.DataAccess.Models.IdentityModel;
using Demo.Presentation.Models;
using Demo.Presentation.Utilities;

namespace Demo.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Register
        #region Register
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = new ApplicationUser
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerViewModel);
        }
        #endregion

        // Login
        #region Login
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl ?? "/");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginViewModel);
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View(loginViewModel);
        }
        #endregion

        //Forgot Password
        #region ForgotPassword
        [HttpGet]
        public IActionResult ForgotPassword() => View();

        [HttpPost]
        public IActionResult SendResestPassowrdLink(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var User = _userManager.FindByEmailAsync(forgetPasswordViewModel.Email).Result;
                if (User is not null)
                {
                    var email = new Email
                    {
                        To = forgetPasswordViewModel.Email,
                        Subject = "Reset Password",
                        Body = "reset password link" //TODO: Generate a reset password link
                    };
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid email address.");
            return View(nameof(ForgotPassword), forgetPasswordViewModel);
        }

        #endregion

        // SignOut
        #region SignOut
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion

        // Helper Methods
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}