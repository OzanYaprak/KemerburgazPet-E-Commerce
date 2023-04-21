using KemerburgazPetShop.Business.Abstract;
using KemerburgazPetShop.WebUI.Extensions;
using KemerburgazPetShop.WebUI.Identity;
using KemerburgazPetShop.WebUI.ViewModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KemerburgazPetShop.WebUI.Controllers
{
    //[AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ICartService _cartService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // cart created start
                _cartService.InitializeCart(user.Id);

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Oops, sanırım biryerlerde yanlışlık yaptın. Alanları tekrar kontrol edebilir misin ?");

            return View(model);
        }





        [HttpGet]
        public IActionResult Login(string ReturnURL = null)
        {
            return View(new LoginViewModel()
            {
                ReturnURL = ReturnURL
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Böyle bir hesap olduğundan emin olamadık.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,true,false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnURL ?? "~/");
            }

            ModelState.AddModelError("", "Oops, sanırım biryerlerde yanlışlık yaptın. Alanları tekrar kontrol edebilir misin ?");

            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }



        public IActionResult Accessdenied()
        {
            return View();
        }
    }
}
