using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IVeiculoRepositorio Veiculo { get; }
        ITipoVeiculoRepositorio TipoVeiculo { get; }
        void Save();
    }
}
