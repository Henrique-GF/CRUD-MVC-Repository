using System.Linq.Expressions;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public interface IRepositorio<T> where T : class
    {
        void Add(T entidade);
        void Delete(T entidade);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null);
        bool Any(Expression<Func<T, bool>> predicate);
    }
}
