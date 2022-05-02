using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        [Display(Name="Nome de Usuário")]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string NomeUsuario { get; set; }
        [DataType(DataType.Password)]
        [MaxLength(20)]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string Senha { get; set; }
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [MaxLength(20)]
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
        public string ConfirmarSenha { get; set; }
    }
}
