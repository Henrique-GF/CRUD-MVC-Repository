using EstoqueVeiculo.DataAccess.Data;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public class Repositorio : IRepositorio
    {
        private readonly Contexto _contexto;

        public Repositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        //Add
        public void Add<T>(T entidade) where T : class
        {
            _contexto.Add(entidade);
        }

        //Update
        public void Update<T>(T entidade) where T : class
        {
            _contexto.Update(entidade);
        }

        //Remove
        public void Remove<T>(T entidade) where T : class
        {
            _contexto.Remove(entidade);
        }

        //Salva alterações
        public async Task<bool> SaveChangesAsync()
        {
            // Só retona sucesso se houver mudança em pelo menos uma linha
            return (await _contexto.SaveChangesAsync()) > 0;
        }


        //GET: Todos
        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _contexto.Set<T>().AsEnumerable();
        }

        public async Task<T> GetById<T>(int id) where T : class
        {
            return _contexto.Set<T>().Find(id);
        }



        public bool Any<T>(int id) where T : class
        {

            return _contexto.Set<T>().Any(e => e.Equals(id));
        }
    }
}
