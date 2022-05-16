using EstoqueProdutos.DataAccess.Data;
using EstoqueProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.DataAccess.Repositories
{
    public class ImagemRepositorio : Repositorio<Imagem>, IImagemRepositorio
    {
        private readonly Contexto _contexto;
        public ImagemRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public void Update(Imagem imagem)
        {
            var imagemDB = _contexto.Imagem.FirstOrDefault(x => x.Id == imagem.Id);
            if (imagemDB != null)
            {
                imagemDB.ImageUrl = imagem.ImageUrl;
                imagemDB.ProdutoId = imagem.ProdutoId;
            }
        }
    }
}
