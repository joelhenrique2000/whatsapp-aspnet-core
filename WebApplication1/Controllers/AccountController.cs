using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Business;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {

        private AccountBusiness _business;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _business = new AccountBusiness(userManager, signInManager);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new AccountLoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _business.Login(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.ErrorMessage = null;
            return View(new ContaRegistrarViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(ContaRegistrarViewModel user)
        {
            if (ModelState.IsValid)
            {
                var usuario = new ApplicationUser()
                {
                    Nome = "jaopdjaspdo",
                    UserName = user.Email,
                    Email = user.Email,
                };

                var result = await _business.Register(usuario, user.Senha);

                if (result.Succeeded)
                {
                    await _business.SignIn(usuario);
                    Console.WriteLine(usuario);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return View(user);

        }

        public async Task<IActionResult> Logout()
        {
            Console.WriteLine("SAINDO");
            await _business.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
