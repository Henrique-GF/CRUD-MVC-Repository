using EstoqueProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.ViewModels
{
    public class EstoqueViewModel
    {
        public Produto Produto { get; set; } = new Produto();
        public IEnumerable<Produto> Produtos = new List<Produto>();
        public Categoria Categoria { get; set; } = new Categoria();
        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();
        public Imagem Imagem { get; set; } = new Imagem();
        public IEnumerable<Imagem> Imagens = null;
    }
}
