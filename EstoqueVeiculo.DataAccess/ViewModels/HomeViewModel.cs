using EstoqueProdutos.Models;

namespace EstoqueProdutos.DataAccess.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produto> Destaques = new List<Produto>();
        public Produto MaiorPreco = null;
        public Produto MenorPreco = null;
        public IEnumerable<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}
