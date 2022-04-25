using EstoqueVeiculo.DataAccess.Repositories;
using EstoqueVeiculo.Models;
using EstoqueVeiculo.DataAccess.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EstoqueVeiculos.Web.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Categorias = _unitOfWork.Categoria.GetAll();
            homeViewModel.Destaques = _unitOfWork.Produto.GetAll(x => x.Destaque==true);
            homeViewModel.Produtos = _unitOfWork.Produto.GetAll();
            homeViewModel.MaiorPreco = _unitOfWork.Produto.GetAll().MaxBy(x => x.Preco);
            homeViewModel.MenorPreco = _unitOfWork.Produto.GetAll().MinBy(x => x.Preco);
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}