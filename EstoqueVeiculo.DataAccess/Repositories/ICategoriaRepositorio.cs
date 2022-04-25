using EstoqueVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria>
    {
        void Update(Categoria tipoVeiculo);
    }
}
