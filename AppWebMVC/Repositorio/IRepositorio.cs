using AppWebMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppWebMVC.Repositorio
{
    public interface IRepositorio
    {
        void Add<T>(T entidade) where T : class;
        void Update<T>(T entidade) where T : class;
        void Remove<T>(T entidade) where T : class;
        Task<bool> SaveChangesAsync();
        IEnumerable<T> GetAll<T>() where T : class;
        Task<T> GetById<T>(int id) where T : class;
        bool Any<T>(int id) where T : class;
    }
}
