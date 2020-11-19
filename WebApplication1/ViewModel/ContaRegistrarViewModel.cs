using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class ContaRegistrarViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        [Required(ErrorMessage = "Confirme sua senha")]
        public string ConfirmarSenha { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

    }
}
