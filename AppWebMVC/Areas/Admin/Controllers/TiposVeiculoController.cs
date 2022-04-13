using EstoqueVeiculo.DataAccess.Repositories;
using EstoqueVeiculo.DataAccess.ViewModels;
using EstoqueVeiculo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstoqueVeiculos.Web.Controllers
{
    [Area("Admin")]
    public class TiposVeiculoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TiposVeiculoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Veiculos
        public IActionResult Index()
        {
            return View(_unitOfWork.TipoVeiculo.GetAll());
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome")] TipoVeiculo tipoVeiculo)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TipoVeiculo.Add(tipoVeiculo);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoVeiculo);
        }

        // GET: Veiculos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVeiculo = _unitOfWork.TipoVeiculo.GetT(x => x.Id == id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }
            return View(tipoVeiculo);
        }

        // POST: Veiculos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoVeiculo tipoVeiculo)
            {
            if (id != tipoVeiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.TipoVeiculo.Update(tipoVeiculo);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(tipoVeiculo.Id))
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
            return View(tipoVeiculo);
        }

        // GET: Veiculos/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoVeiculo = _unitOfWork.TipoVeiculo.GetT(x => x.Id == id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }

            return View(tipoVeiculo);
        }

        // POST: Veiculos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tipoVeiculo = _unitOfWork.TipoVeiculo.GetT(x => x.Id == id);
            _unitOfWork.TipoVeiculo.Delete(tipoVeiculo);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(int id)
        {
            return _unitOfWork.TipoVeiculo.Any(e => e.Id == id);
        }
    }
}
