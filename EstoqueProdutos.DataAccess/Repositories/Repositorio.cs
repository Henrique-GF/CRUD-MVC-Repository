using EstoqueProdutos.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly Contexto _contexto;
        private readonly DbSet<T> _dbSet;

        public Repositorio(Contexto contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<T>();
        }

        //Add
        public void Add(T entidade)
        {
            _contexto.Add(entidade);
        }

        //Update
        public void Update(T entidade)
        {
            _contexto.Update(entidade);
        }

        //Remove
        public void Delete(T entidade)
        {
            _contexto.Remove(entidade);
        }


        //GET: Todos
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public T GetT(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(predicate);

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }



        public bool Any(Expression<Func<T, bool>> predicate)
        {

            return _dbSet.Any(e => e.Equals(predicate));
        }
    }
}
