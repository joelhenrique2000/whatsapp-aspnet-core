using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Business;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Controllers {

    [Authorize]
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly AccountBusiness _business;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            _logger = logger;
            _business = new AccountBusiness(userManager, signInManager);
        }

        public async Task<IActionResult> Index() {

            var idUsuario = await _business.Id();

            LobbyBusiness business = new LobbyBusiness();
            var listaSalas = business.GetAll(idUsuario);

            var viewModel = new LobbyViewModel {
                Salas = listaSalas
            };

            return View(viewModel);
        }

        public IActionResult Entar(int id)
        {
            ViewBag.Status = "Success";
            return RedirectToAction("Index", "Sala", new {
                id = "0as9das0d9asd"+ id,
                nome = "asodijsoid"
            });
        }

        [HttpPost]
        public IActionResult Index(UsuarioIndexViewModel pessoa) {
                Console.WriteLine(pessoa);
            if (ModelState.IsValid) {
                // return View("Sala", pessoa);
                ViewBag.Status = "Success";
                return RedirectToAction("Index", "Sala", new {
                    id = "0as9das0d9asd",
                    nome = pessoa.Nome
                });
            }
            else {
                return View();
            }
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
