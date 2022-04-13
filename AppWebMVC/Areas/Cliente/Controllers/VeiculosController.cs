using EstoqueVeiculo.DataAccess.Repositories;
using EstoqueVeiculo.DataAccess.ViewModels;
using EstoqueVeiculo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstoqueVeiculo.Web.Controllers
{
    [Area("Cliente")]
    public class VeiculosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VeiculosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Veiculos
        public IActionResult Index()
        {
            return View(_unitOfWork.Veiculo.GetAll(includeProperties:"TipoVeiculo"));
        }

        // GET: Veiculos/Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var veiculo = _unitOfWork.Veiculo.GetT(x => x.Id == id, includeProperties: "TipoVeiculo");
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            ViewData["TipoVeiculoId"] = new SelectList(_unitOfWork.TipoVeiculo.GetAll(), "Id", "Nome");
            return View();
        }

        // POST: Veiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,TipoVeiculoId,Placa,Marca,Modelo,Versao,AnoFabricacao,AnoModelo")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Veiculo.Add(veiculo);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoVeiculoId"] = new SelectList(_unitOfWork.TipoVeiculo.GetAll(), "Id", "Nome");
            return View(veiculo);
        }

        // GET: Veiculos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = _unitOfWork.Veiculo.GetT(x => x.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }
            ViewData["TipoVeiculoId"] = new SelectList(_unitOfWork.TipoVeiculo.GetAll(), "Id", "Nome");
            return View(veiculo);
        }

        // POST: Veiculos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoVeiculoId,Placa,Marca,Modelo,Versao,AnoFabricacao,AnoModelo")] Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Veiculo.Update(veiculo);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculo.Id))
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
            ViewData["TipoVeiculoId"] = new SelectList(_unitOfWork.TipoVeiculo.GetAll(), "Id", "Nome");
            return View(veiculo);
        }

        // GET: Veiculos/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = _unitOfWork.Veiculo.GetT(x => x.Id == id, includeProperties: "TipoVeiculo");
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // POST: Veiculos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var veiculo = _unitOfWork.Veiculo.GetT(x => x.Id == id);
            _unitOfWork.Veiculo.Delete(veiculo);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(int id)
        {
            return _unitOfWork.Veiculo.Any(e => e.Id == id);
        }
    }
}
