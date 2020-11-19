using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Conta
    {
        public string Id { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public string Email { get; set; }
    }
}
