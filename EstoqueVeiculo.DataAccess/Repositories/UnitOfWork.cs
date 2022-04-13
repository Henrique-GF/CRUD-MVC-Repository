using EstoqueVeiculo.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;

        public IVeiculoRepositorio Veiculo { get; private set; }
        public ITipoVeiculoRepositorio TipoVeiculo { get; private set; }
        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
            Veiculo = new VeiculoRepositorio(contexto);
            TipoVeiculo = new TipoVeiculoRepositorio(contexto);
        }
        public void Save()
        {
            _contexto.SaveChanges();
        }
    }
}
