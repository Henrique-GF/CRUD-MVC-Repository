using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueVeiculo.Models
{
    [Table("Veiculo")]
    public class Veiculo
    {
        [Key, Column("Id")]
        public int Id { get; set; }
        [ForeignKey("TipoVeiculo")]
        public int TipoVeiculoId { get; set; }
        [ValidateNever]
        public TipoVeiculo TipoVeiculo { get; set; }
        [Required, MaxLength(9)]
        public string Placa { get; set; }
        [Required, MaxLength(20)]
        public string Marca { get; set; }
        [Required, MaxLength(20)]
        public string Modelo { get; set; }
        [Required, MaxLength(20)]
        public string Versao { get; set; }
        [Required]
        public int AnoFabricacao { get; set; }
        [Required]
        public int AnoModelo { get; set; }

    }
}