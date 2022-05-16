using EstoqueProdutos.Domain.Commands.Requests;
using EstoqueProdutos.Domain.Commands.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.Domain.Handlers.Produto
{
    public interface IProdutoHandler
    {
        ProdutoResponse Create(ProdutoRequest produto, IFormFile? file);
    }
}
