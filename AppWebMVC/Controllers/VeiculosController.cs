using EstoqueVeiculo.DataAccess.Repositories;
using EstoqueVeiculo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebMVC.Controllers
{
    public class VeiculosController : Controller
    {
        //private readonly Contexto _context;
        private readonly IRepositorio _repositorio;

        public VeiculosController(IRepositorio repositorio)
        {
            //_context = context;
            _repositorio = repositorio;
        }

        // GET: Veiculos
        public async Task<IActionResult> Index()
        {
            return View(_repositorio.GetAll<Veiculo>());
        }

        // GET: Veiculos/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var veiculo = await _repositorio.GetById<Veiculo>(id.GetValueOrDefault());
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,Marca,Modelo,Versao,AnoFabricacao,AnoModelo")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Add(veiculo);
                await _repositorio.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // GET: Veiculos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _repositorio.GetById<Veiculo>(id.GetValueOrDefault());
            if (veiculo == null)
            {
                return NotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Marca,Modelo,Versao,AnoFabricacao,AnoModelo")] Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repositorio.Update(veiculo);
                    await _repositorio.SaveChangesAsync();
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
            return View(veiculo);
        }

        // GET: Veiculos/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculo = await _repositorio.GetById<Veiculo>(id.GetValueOrDefault());
            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);
        }

        // POST: Veiculos/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veiculo = await _repositorio.GetById<Veiculo>(id);
            _repositorio.Remove(veiculo);
            await _repositorio.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(int id)
        {
            return _repositorio.Any<Veiculo>(id);
        }
    }
}
