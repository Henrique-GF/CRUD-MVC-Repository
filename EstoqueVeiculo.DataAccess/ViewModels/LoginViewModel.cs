using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name= "Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Usuario { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
        [Required]
        [Display(Name = "Lembrar de mim")]
        public bool Lembrar { get; set; }
        public string ReturnUrl { get; set; }
    }
}
