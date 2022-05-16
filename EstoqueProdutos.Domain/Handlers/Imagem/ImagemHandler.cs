using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueProdutos.Domain.Handlers.Imagem
{
    public class ImagemHandler
    {
        private IWebHostEnvironment _hostEnvironment;

        public ImagemHandler(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public string SetFilePath(IFormFile? file)
        {
            string fileName = String.Empty;
            if (file != null)
            {
                string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "img");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);


                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return @"\img\" + fileName;
            }
            return null;
        }
    }
}
