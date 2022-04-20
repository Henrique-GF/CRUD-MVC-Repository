using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IProdutoRepositorio Produto { get; }
        ICategoriaRepositorio Categoria { get; }
        void Save();
    }
}
