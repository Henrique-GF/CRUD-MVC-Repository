using System.ComponentModel.DataAnnotations;

namespace EstoqueVeiculo.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Nome { get; set; }
    }
}
