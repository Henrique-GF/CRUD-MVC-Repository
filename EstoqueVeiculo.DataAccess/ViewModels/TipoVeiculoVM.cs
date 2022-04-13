using EstoqueVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.ViewModels
{
    public class TipoVeiculoVM
    {
        public TipoVeiculo TipoVeiculo { get; set; } = new TipoVeiculo();
        public IEnumerable<TipoVeiculo> TipoVeiculos { get; set; } = new List<TipoVeiculo>();
    }
}
