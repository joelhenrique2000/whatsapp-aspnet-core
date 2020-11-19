using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class AccountLoginViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Senha { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

    }
}
