using EstoqueVeiculo.DataAccess.Data;
using EstoqueVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueVeiculo.DataAccess.Repositories
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly Contexto _contexto;
        public CategoriaRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void Update(Categoria categoria)
        {
            var categoriaDB = _contexto.Categoria.FirstOrDefault(x => x.Id == categoria.Id);
            if (categoriaDB != null)
            {
                categoriaDB.Nome = categoria.Nome;
            }
        }
    }
}
