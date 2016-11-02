using Shopy.Logic.Interface.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopy.Entity;

namespace Shopy.Logic
{
    public sealed class ImageRepository : IImageRepository
    {
        public Task AddImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImagesFromProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
