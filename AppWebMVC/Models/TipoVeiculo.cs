using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebMVC.Models
{
    [Table("TipoVeiculo")]
    public class TipoVeiculo
    {
        [Key]
        public int Id { get; set; }
        [Column("Nome"), MaxLength(10)]
        public string Nome { get; set; }
    }
}
