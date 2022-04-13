using EstoqueVeiculo.DataAccess.Data;
using EstoqueVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public class TipoVeiculoRepositorio : Repositorio<TipoVeiculo>, ITipoVeiculoRepositorio
    {
        private readonly Contexto _contexto;
        public TipoVeiculoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void Update(TipoVeiculo tipoVeiculo)
        {
            var tipoVeiculoDB = _contexto.TipoVeiculo.FirstOrDefault(x => x.Id == tipoVeiculo.Id);
            if (tipoVeiculoDB != null)
            {
                tipoVeiculoDB.Nome = tipoVeiculo.Nome;
            }
        }
    }
}
