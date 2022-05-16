using EstoqueProdutos.DataAccess.Repositories;
using EstoqueProdutos.Domain.Commands.Requests;
using EstoqueProdutos.Domain.Commands.Responses;
using EstoqueProdutos.Domain.Handlers.Imagem;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.Domain.Handlers.Produto
{
    public class ProdutoHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private IImagemHandler _imageHandler;

        public ProdutoHandler(IUnitOfWork unitOfWork, IImagemHandler imageHandler)
        {
            _unitOfWork = unitOfWork;
            _imageHandler = imageHandler;
        }

        public ProdutoResponse Create(ProdutoRequest produto, IFormFile? file)
        {
            //if (_imageHandler.SetFilePath(file) != null)
            //{
            //    produto.ImageUrl = _imageHandler.SetFilePath(file);
            //}

            var novoProduto = new ProdutoResponse
            {
                Id = produto.Id,
                CategoriaId = produto.CategoriaId,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Descricao = produto.Descricao,
                Destaque = produto.Destaque,
            };

            _unitOfWork.Produto.Add(novoProduto);
            _unitOfWork.Save();

            return novoProduto;
        }
    }
}
