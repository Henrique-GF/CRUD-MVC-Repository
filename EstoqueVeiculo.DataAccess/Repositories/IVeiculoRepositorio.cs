using EstoqueVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public interface IVeiculoRepositorio : IRepositorio<Veiculo>
    {
        void Update(Veiculo veiculo);
    }
}
