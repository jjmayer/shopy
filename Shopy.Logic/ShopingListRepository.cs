using Shopy.Logic.Interface.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopy.Entity;
using Shopy.DataAccess;
using System.Data.Entity;

namespace Shopy.Logic
{
    public sealed class ShopingListRepository : IShopingListRepository
    {
        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task AddShop(Shop shop)
        {
            throw new NotImplementedException();
        }

        public Task AddShopingItem(ShopingItem item, ShopingList list)
        {
            throw new NotImplementedException();
        }

        public Task<ShopingList> FinishShopingList(ShopingList list)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts(ShopingList shopingList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shop>> GetAllShops(ShopingList shopingList)
        {
            throw new NotImplementedException();
        }

        public async Task<ShopingList> GetCurrentShopingList(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            using (var ctx = new ShopyContext())
            {
                return await (from sl in ctx.ShopingLists.Include(list => list.Users).IncludeShopingItems()
                        where sl.Finished == null && (from u in sl.Users
                                                      select u.Id).Contains(user.Id)
                        select sl).AsNoTracking().SingleOrDefaultAsync().ConfigureAwait(false);
            }
        }

        public Task<IEnumerable<ShopingItem>> GetShopingItems(ShopingList list)
        {
            throw new NotImplementedException();
        }

        public Task RemoveShopingItem(ShopingItem item)
        {
            throw new NotImplementedException();
        }
    }
}
