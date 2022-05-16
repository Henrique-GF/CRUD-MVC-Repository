using EstoqueProdutos.Models;
using EstoqueProdutos.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public class PerfilRepositorio : Repositorio<Perfil>, IPerfilRepositorio
    {
        private readonly Contexto _contexto;

        public PerfilRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void Update(Perfil perfil)
        {
            var perfilDB = _contexto.Perfil.FirstOrDefault(x => x.Id == perfil.Id);
            if (perfilDB != null)
            {
                perfilDB.Nome = perfil.Nome;
            }
        }
    }
}
