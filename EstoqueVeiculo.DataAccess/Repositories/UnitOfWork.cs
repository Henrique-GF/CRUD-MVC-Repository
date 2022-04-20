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

        public IProdutoRepositorio Produto { get; private set; }
        public ICategoriaRepositorio Categoria { get; private set; }
        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
            Produto = new ProdutoRepositorio(contexto);
            Categoria = new CategoriaRepositorio(contexto);
        }
        public void Save()
        {
            _contexto.SaveChanges();
        }
    }
}
