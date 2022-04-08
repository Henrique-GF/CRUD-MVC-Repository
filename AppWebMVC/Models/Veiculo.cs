using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebMVC.Models
{
    [Table("Veiculo")]
    public class Veiculo
    {
        [Key, Column("Id")]
        public int Id { get; set;}
        [Column("Placa"), MaxLength(9)]
        public string Placa { get; set;}
        [Column("Marca"), MaxLength(20)]
        public string Marca { get; set;}
        [Column("Modelo"), MaxLength(20)]
        public string Modelo { get; set; }
        [Column("Versao"), MaxLength(20)]
        public string Versao { get; set; }
        [Column("AnoFabricacao")]
        public int AnoFabricacao { get; set; }
        [Column("AnoModelo")]
        public int AnoModelo { get; set; }
        //[Column("TipoVeiculoId"), ForeignKey("TipoVeiculo")]
        //public int TipoVeiculoId { get; set; }
        //[Column("TipoVeiculoNome"), MaxLength(10)]
        //public TipoVeiculo TipoVeiculoNome { get; set; }
    }
}
