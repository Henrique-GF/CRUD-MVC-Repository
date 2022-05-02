using EstoqueProdutos.DataAccess.Repositories;
using EstoqueProdutos.DataAccess.ViewModels;
using EstoqueProdutos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueProdutos.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuariosController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _userManager.Users.AsNoTracking().ToListAsync();
            return View(usuarios);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeUsuario,Senha,ConfirmarSenha")] UsuarioViewModel usuarioVM)
        {
            var usuarioBD = await _userManager.FindByNameAsync(usuarioVM.NomeUsuario);
            if (usuarioBD != null)
            {
                ModelState.AddModelError("Usuario", "Já existe um usuário cadastrado com este nome.");
                return View(usuarioVM);
            }

            if (usuarioVM.Senha == usuarioVM.ConfirmarSenha)
            {
                usuarioBD = new IdentityUser();
                MapearUsuarioViewModel(usuarioVM, usuarioBD);

                var resultado = await _userManager.CreateAsync(usuarioBD, usuarioVM.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Admin/Login");
                }
                else
                {
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(usuarioVM);
                }
            }
            else
            {
                ModelState.AddModelError("ConfirmarSenha", "A senha e a confirmação de senha não conferem.");
                return View(usuarioVM);
            }
        }

        // GET: Categorias/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioBD = await _userManager.FindByIdAsync(id.ToString());
            if (usuarioBD == null)
            {
                return NotFound();
            }
            var usuarioVM = new UsuarioViewModel
            {
                Id = usuarioBD.Id,
                NomeUsuario = usuarioBD.UserName
            };

            return View(usuarioVM);
        }

        // POST: Categorias/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nome")] UsuarioViewModel usuarioVM)
        {

            if (!UsuarioExiste(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var usuarioBD = await _userManager.FindByIdAsync(usuarioVM.Id);
                if ((usuarioVM.NomeUsuario != usuarioBD.UserName) && 
                    (_userManager.Users.Any(u => u.NormalizedUserName == usuarioVM.NomeUsuario.ToUpper().Trim())))
                {
                    ModelState.AddModelError("Usuario", "Já existe um usuário cadastrado com este nome.");
                    return View(usuarioVM);
                }
                MapearUsuarioViewModel(usuarioVM, usuarioBD);

                var resultado = await _userManager.UpdateAsync(usuarioBD);
                if (resultado.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in resultado.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(usuarioVM);
                }
            }
            return View(usuarioVM);
        }

        // GET: Categorias/Delete
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            if (!UsuarioExiste(id))
            {
                return NotFound();
            }

            var usuario = await _userManager.FindByIdAsync(id);

            return View(usuario);
        }

        // POST: Categorias/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario != null)
            {
                var resultado = await _userManager.DeleteAsync(usuario);
                if (resultado.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Usuario", "Não foi possível exluir o usuário");
                    return View(usuario);
                }
            }
            return NotFound();
        }

        private bool UsuarioExiste(string id)
        {
            return _userManager.Users.AsNoTracking().Any(e => e.Id == id);
        }

        private static void MapearUsuarioViewModel (UsuarioViewModel origem, IdentityUser destino)
        {
            destino.UserName = origem.NomeUsuario;
            destino.NormalizedUserName = origem.NomeUsuario.ToUpper().Trim();
        }
    }
}
