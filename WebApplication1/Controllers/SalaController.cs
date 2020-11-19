using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.ViewModel;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using WebApplication1.Business;

namespace WebApplication1.Controllers {

    [Authorize]
    public class SalaController : Controller {
        //[HttpGet("{id}")]//  [FromQuery(Name = "nome")] string nome
        private AccountBusiness _business;

        public SalaController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            _business = new AccountBusiness(userManager, signInManager);
        }

        public IActionResult Index(string id) {

            ViewData["nome"] = (string) _business.Nome();
            ViewData["sala"] = (string) id;

            return View();
        }

        [HttpPost] 
        public IActionResult Index(UsuarioIndexViewModel pessoa) {
            if (ModelState.IsValid) {
                return View(pessoa);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AdicionarMembro(SalaIndexViewModel sala) {
            Console.WriteLine(sala.NomeSala);
            Console.WriteLine(sala.NomeUsuario);
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(SalaCadastrarViewModel sala) {
            if (ModelState.IsValid) {
                SalaBusiness business = new SalaBusiness();

                var idUsuario = await _business.Id();

                Sala salaCriada = new Sala() {
                    Titulo = sala.Nome,
                    Id = 12,
                    IdUsuario = idUsuario
                };

                Console.WriteLine(salaCriada.Titulo);
                Console.WriteLine(_business.Nome());
                Console.WriteLine(salaCriada.IdUsuario);

                business.Create(salaCriada);

                return RedirectToAction("Index", "Home");

            } else {
                return View();
            }
        }
    }
}
