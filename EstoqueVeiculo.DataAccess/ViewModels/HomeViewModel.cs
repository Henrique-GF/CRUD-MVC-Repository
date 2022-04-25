using EstoqueVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produto> Destaques = new List<Produto>();
        public IEnumerable<Produto> Produtos = new List<Produto>();
        public Produto MaiorPreco = new Produto();
        public Produto MenorPreco = new Produto();
        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}
