using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using System.Threading.Tasks;
using System;

namespace WebApplication1.Business
{
    public class AccountBusiness
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public string Nome() 
        {
            var a =  this._signInManager.Context.User.Identity;
            return a.Name;
        }

        public async Task<string> Id()
        {
            var user = await GetCurrentUserAsync();
            return user.Id;
        }

        public Task<ApplicationUser> GetCurrentUserAsync() => this._userManager.GetUserAsync(this._signInManager.Context.User);

        public AccountBusiness(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task<SignInResult> Login(AccountLoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Senha, false, false);
            return result;
        }

        public async Task<IdentityResult> Register(ApplicationUser usuario, string senha)
        {
            
            return await _userManager.CreateAsync(usuario, senha);
        }

        public async Task SignIn(ApplicationUser usuario)
        {
            await _signInManager.SignInAsync(usuario, false);
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
