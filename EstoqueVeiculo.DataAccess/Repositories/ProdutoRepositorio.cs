using EstoqueProdutos.Models;
using EstoqueProdutos.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        private readonly Contexto _contexto;
        public ProdutoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void Update(Produto produto)
        {
            var produtoDB = _contexto.Produto.FirstOrDefault(x => x.Id == produto.Id);
            if (produtoDB != null)
            {
                produtoDB.CategoriaId = produto.CategoriaId;
                produtoDB.Nome = produto.Nome;
                produtoDB.Preco = produto.Preco;
                produtoDB.Descricao = produto.Descricao;
                produtoDB.ImageUrl = produto.ImageUrl;
                produtoDB.Destaque = produto.Destaque;
            }
        }
    }
}
