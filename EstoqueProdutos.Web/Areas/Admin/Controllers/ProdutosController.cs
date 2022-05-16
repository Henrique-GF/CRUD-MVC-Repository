using EstoqueProdutos.DataAccess.Repositories;
using EstoqueProdutos.DataAccess.ViewModels;
using EstoqueProdutos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProdutos.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public ProdutosController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            ProdutoViewModel produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Produtos = _unitOfWork.Produto.GetAll(includeProperties: "Categoria");
            produtoViewModel.Imagens = _unitOfWork.Imagem.GetAll(includeProperties: "Produto");
            return View(produtoViewModel);
        }

        // GET: Produtos/Details
        public IActionResult Details(int? id)
        {
            ProdutoViewModel produtoViewModel = new ProdutoViewModel();
            if (id == null)
            {
                return NotFound();
            }
            produtoViewModel.Produto = _unitOfWork.Produto.GetT(x => x.Id == id, includeProperties: "Categoria");
            produtoViewModel.Imagem = _unitOfWork.Imagem.GetT(x => x.ProdutoId == id, includeProperties: "Produto");
            if (produtoViewModel.Produto == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["Categorias"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CategoriaId,Nome,Preco,Descricao,Destaque")] Produto produto, List<IFormFile>? files)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Produto.Add(produto);
                _unitOfWork.Save();
                string fileName = String.Empty;
                if (files != null)
                {
                    foreach (var item in files)
                    {
                        Imagem imagem = new Imagem();
                        imagem.ProdutoId = produto.Id;
                        string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "img");
                        fileName = Guid.NewGuid().ToString() + "-" + item.FileName;
                        string filePath = Path.Combine(uploadDir, fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            item.CopyTo(fileStream);
                        }

                        imagem.ImageUrl = @"\img\" + fileName;
                        _unitOfWork.Imagem.Add(imagem);
                        _unitOfWork.Save();
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categorias"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Id", "Nome");

            return View(produto);
        }

        // GET: Produtos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            ProdutoViewModel produtoViewModel = new ProdutoViewModel();
            if (id == null)
            {
                return NotFound();
            }

            produtoViewModel.Produto = _unitOfWork.Produto.GetT(x => x.Id == id, includeProperties: "Categoria");
            produtoViewModel.Imagem = _unitOfWork.Imagem.GetT(x => x.ProdutoId == id, includeProperties: "Produto");
            if (produtoViewModel.Produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Id", "Nome");
            return View(produtoViewModel);
        }

        // POST: Produtos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoriaId,Nome,Preco,Descricao,ImageUrl,Destaque")] Produto produto, List<IFormFile>? files)
        {
            ProdutoViewModel produtoViewModel = new ProdutoViewModel();

            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                string fileName = String.Empty;
                if (files != null)
                {
                    foreach (var item in files)
                    {
                        Imagem imagem = new Imagem();
                        imagem.ProdutoId = produto.Id;
                        string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "ProductImage");
                        fileName = Guid.NewGuid().ToString() + "-" + item.FileName;
                        string filePath = Path.Combine(uploadDir, fileName);

                        if (imagem.ImageUrl != null)
                        {
                            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, imagem.ImageUrl.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                           item.CopyTo(fileStream);
                        }
                        imagem.ImageUrl = @"\ImagemProduto\" + fileName;
                        try
                        {
                            _unitOfWork.Imagem.Update(imagem);
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ProdutoExists(imagem.ProdutoId))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        produtoViewModel.Imagem = imagem;
                    }
                }

                try
                {
                    _unitOfWork.Produto.Update(produto);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            
            produtoViewModel.Produto = produto;

            ViewData["CategoriaId"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Id", "Nome");
            return View(produtoViewModel);
        }

        // GET: Produtos/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = _unitOfWork.Produto.GetT(x => x.Id == id, includeProperties: "Categoria");
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = _unitOfWork.Produto.GetT(x => x.Id == id);
            var imagem = _unitOfWork.Imagem.GetAll(x => x.Id == id);
            foreach (var item in imagem)
            {
                _unitOfWork.Imagem.Delete(item);
            }
            _unitOfWork.Produto.Delete(produto);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _unitOfWork.Produto.Any(e => e.Id == id);
        }
    }
}
