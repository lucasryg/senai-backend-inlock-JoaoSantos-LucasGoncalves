using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o email!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}
