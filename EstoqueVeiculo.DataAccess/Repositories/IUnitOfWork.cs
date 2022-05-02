using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IProdutoRepositorio Produto { get; }
        ICategoriaRepositorio Categoria { get; }
        IUsuarioRepositorio Usuario { get; }
        void Save();
    }
}
