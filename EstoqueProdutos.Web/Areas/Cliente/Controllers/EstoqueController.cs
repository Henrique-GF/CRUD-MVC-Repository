using EstoqueProdutos.DataAccess.Repositories;
using EstoqueProdutos.DataAccess.ViewModels;
using EstoqueProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EstoqueProdutos.Web.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class EstoqueController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstoqueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            EstoqueViewModel estoqueViewModel = new EstoqueViewModel();


            if (!string.IsNullOrEmpty(Request.Query["Categoria"].ToString()))
            {
                estoqueViewModel.Categorias = _unitOfWork.Categoria.GetAll(x => x.Nome == Request.Query["Categoria"].ToString());
                estoqueViewModel.Categoria = _unitOfWork.Categoria.GetT(x => x.Nome == Request.Query["Categoria"].ToString());
            }
            else
            {
                estoqueViewModel.Categorias = _unitOfWork.Categoria.GetAll();
            }

            estoqueViewModel.Produtos = _unitOfWork.Produto.GetAll(includeProperties: "Categoria");
            estoqueViewModel.Imagens = _unitOfWork.Imagem.GetAll(includeProperties:"Produto");



            ViewData["Categoria"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Nome", "Nome");
            return View(estoqueViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EstoqueViewModel estoqueViewModel = new EstoqueViewModel();
            estoqueViewModel.Produto = _unitOfWork.Produto.GetT(x => x.Id == id, includeProperties: "Categoria");
            estoqueViewModel.Imagens = _unitOfWork.Imagem.GetAll(x => x.ProdutoId == id, includeProperties: "Produto");
            if (estoqueViewModel.Produto == null)
            {
                return NotFound();
            }

            return View(estoqueViewModel);
        }
    }
}
