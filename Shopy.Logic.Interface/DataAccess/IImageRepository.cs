using Shopy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Logic.Interface.DataAccess
{
    public interface IImageRepository
    {
        /// <summary>
        /// Gets alls images which have been associated with the given product
        /// </summary>
        Task<Image> GetImagesFromProduct(Product product);
        Task AddImage(Image image);
    }
}
