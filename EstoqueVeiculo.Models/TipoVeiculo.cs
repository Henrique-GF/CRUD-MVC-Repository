using System.ComponentModel.DataAnnotations;

namespace EstoqueVeiculo.Models
{
    public class TipoVeiculo
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string Nome { get; set; }
    }
}
