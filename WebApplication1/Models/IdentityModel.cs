using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class IdentityModel
    {
    }

    public class ApplicationUserRole : IdentityRole
    {
    }

    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
    }
}
