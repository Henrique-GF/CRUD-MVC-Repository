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
    public class Imagem
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }
        [ValidateNever]
        public Produto Produto { get; set; }
    }
}
