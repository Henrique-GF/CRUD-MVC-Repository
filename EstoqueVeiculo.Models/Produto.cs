using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueProdutos.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        [ForeignKey("TipoVeiculo")]
        public int CategoriaId { get; set; }
        [ValidateNever]
        public Categoria Categoria { get; set; }
        [Required, MaxLength(30)]
        public string Nome { get; set; }
        [Required]
        public float Preco { get; set; }
        [Required]
        public string Descricao { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        public bool Destaque { get; set; }
    }
}