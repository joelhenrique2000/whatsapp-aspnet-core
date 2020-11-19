using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Models;

namespace SignalRChat.Hubs {
    public class ChatHub : Hub {

        private AccountBusiness _business;

        public ChatHub(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) {
            _business = new AccountBusiness(userManager, signInManager);
        }

        public async Task SendMessage(string sala, string user, string message) {
            Console.WriteLine("aaaaaaaaaaaa", user, _business.Nome());
            Console.WriteLine(user);
            Console.WriteLine(_business.Nome());
            await Groups.AddToGroupAsync(Context.ConnectionId, sala);
            // await Clients.All.SendAsync("sala", user, sala);

            await Clients.Group(sala).SendAsync("sala", user, message);


            //await Clients.All.SendAsync(sala, user, Context.ConnectionId);
            //await Clients.Client("abc").SendAsync(sala, user, message);
            //  await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}