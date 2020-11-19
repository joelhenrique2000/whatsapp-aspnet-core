using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class ContaController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public ContaController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            this._signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Entrar(string returnUrl)
        {
            if(Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            } else
            {
                return View(new AccountLoginViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Senha, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Pessoa");
                }
                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            ViewBag.ErrorMessage = null;
            return View(new ContaRegistrarViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(ContaRegistrarViewModel user)
        {
            if (ModelState.IsValid)
            {
                var usuario = new ApplicationUser()
                {
                    Nome = "JOASIDJOIJO",
                    UserName = user.Email,
                    Email = user.Email,
                };

                var result = await _userManager.CreateAsync(usuario, user.Senha);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(usuario, false);

                    return RedirectToAction("Index", "Pessoa");
                    // return View("CadastradoSucesso", viewModel);
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
            Console.WriteLine("asdasdasd");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Pessoa");
        }
    }
}