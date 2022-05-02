using EstoqueProdutos.Models;
using EstoqueProdutos.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly Contexto _contexto;

        public UsuarioRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void Update(Usuario usuario)
        {
            var usuarioDB = _contexto.Usuario.FirstOrDefault(x => x.Id == usuario.Id);
            if (usuarioDB != null)
            {
                usuarioDB.Nome = usuario.Nome;
                usuarioDB.Senha = usuario.Senha;
            }
        }

        public Usuario GetByCredentials(string usuario, string senha)
        {
            if (!_contexto.Usuario.Any(x => x.Nome==usuario) || !_contexto.Usuario.Any(x => x.Senha == senha))
            {
                return null;
            }
            else
            {
                Usuario conta = _contexto.Usuario.Where(x => x.Nome==usuario).FirstOrDefault();
                return conta;
            }
        }
    }
}
