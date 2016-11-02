using Shopy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Shopy.Logic
{
    public static class DbLinqExtension
    {
        public static IQueryable<ShopingList> IncludeShopingItems(this IQueryable<ShopingList> sList)
        {
            return sList.Include(list =>
                       list.ShopingItems.Select(item => item.Product));
        }
    }
}
