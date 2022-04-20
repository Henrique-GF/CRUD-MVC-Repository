using EstoqueVeiculo.DataAccess.Repositories;
using EstoqueVeiculo.DataAccess.ViewModels;
using EstoqueVeiculo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstoqueVeiculos.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            return View(_unitOfWork.Produto.GetAll(includeProperties:"Categoria"));
        }

        // GET: Produtos/Details
        public IActionResult Details(int? id)
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

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["Categorias"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CategoriaId,Nome,Preco,Descricao,ImageUrl,Destaque")] Produto produto, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string fileName = String.Empty;
                if (file != null)
                {
                    string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "img");
                    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);
                

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    produto.ImageUrl = @"\img\" + fileName;

                }

                _unitOfWork.Produto.Add(produto);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categorias"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Id", "Nome");
            return View(produto);
        }

        // GET: Produtos/Edit
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["CategoriaId"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Id", "Nome");
            return View(produto);
        }

        // POST: Produtos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoriaId,Nome,Preco,Descricao,ImageUrl,Destaque")] Produto produto, IFormFile? file)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string fileName = String.Empty;
                if (file != null)
                {
                    string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "ProductImage");
                    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);

                    if (produto.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, produto.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    produto.ImageUrl = @"\ImagemProduto\" + fileName;

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
            ViewData["CategoriaId"] = new SelectList(_unitOfWork.Categoria.GetAll(), "Id", "Nome");
            return View(produto);
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
            var veiculo = _unitOfWork.Produto.GetT(x => x.Id == id);
            _unitOfWork.Produto.Delete(veiculo);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _unitOfWork.Produto.Any(e => e.Id == id);
        }
    }
}
