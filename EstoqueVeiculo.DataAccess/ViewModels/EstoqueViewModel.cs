using EstoqueVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.ViewModels
{
    public class EstoqueViewModel
    {
        public Produto Produto { get; set; } = new Produto();
        public IEnumerable<Produto> Produtos = new List<Produto>();
        public Categoria Categoria { get; set; } = new Categoria();
        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}
