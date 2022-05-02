using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
