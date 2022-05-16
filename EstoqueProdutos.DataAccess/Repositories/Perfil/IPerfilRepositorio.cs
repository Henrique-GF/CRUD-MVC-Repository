using EstoqueProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public interface IPerfilRepositorio : IRepositorio<Perfil>
    {
        void Update(Perfil perfil);

    }
}
