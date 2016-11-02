using Shopy.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.DataAccess
{
    public sealed class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ShopyContext>
    {
        protected override void Seed(ShopyContext context)
        {
            var shopingList = new Entity.ShopingList();
            var adminUser = new Entity.User {
                Username = "Admin",
                PasswordHash = "d033e22ae348aeb5660fc2140aec35850c4da997"
            };
            var prod = new Product { Productname = "Item 1" };
            var shop = new Shop { Shopname = "Location 1" };
            var shopingItem = new ShopingItem { Note = "Note 1", QuantityDescription = "200dg", Priority = true };

            shopingList.Users.Add(adminUser);
            shopingList.ShopingItems.Add(shopingItem);

            context.Users.Add(adminUser);
            context.ShopingItems.Add(shopingItem);
            context.ShopingLists.Add(shopingList);

            try
            {
                context.SaveChanges();
            }
            catch(DataException)
            {
                adminUser.ShopingListId = shopingList.Id;
                shopingItem.ShopingListId = shopingList.Id;
                shopingItem.UserId = adminUser.Id;
                shopingItem.ProductId = prod.Id;
                shopingItem.ShopId = shop.Id;

                context.SaveChanges();
            }

            context.Database.ExecuteSqlCommand("ALTER TABLE [Shopy].[dbo].[User] ADD CONSTRAINT uq_user_username UNIQUE(username)");

            base.Seed(context);
        }
    }
}
