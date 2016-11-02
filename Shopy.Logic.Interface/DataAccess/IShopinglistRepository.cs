using Shopy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Logic.Interface.DataAccess
{
    public interface IShopingListRepository
    {
        Task<ShopingList> FinishShopingList(ShopingList list);
        Task<ShopingList> GetCurrentShopingList(User user);
        Task<IEnumerable<ShopingItem>> GetShopingItems(ShopingList list);
        Task AddShopingItem(ShopingItem item, ShopingList list);
        /// <summary>
        /// Finds all products that have ever been created by a shopinglist including its prior shoping lists
        /// </summary>
        Task<IEnumerable<Product>> GetAllProducts(ShopingList shopingList);
        /// <summary>
        /// Finds all shops that have ever been created by a shopinglist including its prior shoping lists
        /// </summary>
        Task<IEnumerable<Shop>> GetAllShops(ShopingList shopingList);
        Task AddProduct(Product product);
        Task AddShop(Shop shop);
        Task RemoveShopingItem(ShopingItem item);
    }
}
