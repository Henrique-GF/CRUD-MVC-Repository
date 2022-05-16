using EstoqueProdutos.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _contexto;

        public IProdutoRepositorio Produto { get; private set; }
        public ICategoriaRepositorio Categoria { get; private set; }
        public IPerfilRepositorio Perfil { get; private set; }
        public IImagemRepositorio Imagem { get; private set; }
        public UnitOfWork(Contexto contexto)
        {
            _contexto = contexto;
            Produto = new ProdutoRepositorio(contexto);
            Categoria = new CategoriaRepositorio(contexto);
            Perfil = new PerfilRepositorio(contexto);
            Imagem = new ImagemRepositorio(contexto);
        }
        public void Save()
        {
            _contexto.SaveChanges();
        }
    }
}
