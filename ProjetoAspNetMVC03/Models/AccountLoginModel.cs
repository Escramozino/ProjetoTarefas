using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC03.Models
{
    public class AccountLoginModel
    {
        [EmailAddress (ErrorMessage ="Por favor, digite um email válido.")]
        [Required(ErrorMessage = "Por favor, informe seu email.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Por favor, informe sua senha.")]
        [MinLength(8, ErrorMessage= "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string Senha { get; set; }
    }
}
