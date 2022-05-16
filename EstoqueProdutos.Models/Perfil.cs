using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
        public string Nome { get; set; }
    }
}
