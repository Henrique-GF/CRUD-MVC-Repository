using EstoqueProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.Domain.Commands.Requests
{
    public class ProdutoRequest : Produto
    {
        public new int Id { get; set; }
        public new int CategoriaId { get; set; }
        public new string Nome { get; set; }
        public new float Preco { get; set; }
        public new string Descricao { get; set; }
        public new bool Destaque { get; set; }
    }
}
