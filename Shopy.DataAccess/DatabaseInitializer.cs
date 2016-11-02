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
            var shopingList = new Entity.ShopingList { Id="a" };
            var adminUser = new Entity.User {
                Username = "Admin",
                PasswordHash = "d033e22ae348aeb5660fc2140aec35850c4da997",
                Id="e"
            };
            var prod = new Product { Productname = "Item 1", Id="b" };
            var shop = new Shop { Shopname = "Location 1", Id = "c" };
            var shopingItem = new ShopingItem { Note = "Note 1", QuantityDescription = "200dg", Priority = true, Id = "d" };

            shopingList.Users.Add(adminUser);
            shopingList.ShopingItems.Add(shopingItem);

            context.Users.Add(adminUser);
            context.Products.Add(prod);
            context.Shops.Add(shop);
            context.ShopingItems.Add(shopingItem);
            context.ShopingLists.Add(shopingList);

            try
            {
                context.SaveChanges(generateId: false);
            }
            catch(DataException)
            {
                adminUser.ShopingListId = "a";
                shopingItem.ShopingListId = "a";
                shopingItem.UserId = "e";
                shopingItem.ProductId = "b";
                shopingItem.ShopId = "c";

                try
                {
                    context.SaveChanges(generateId: false);
                }
                catch(DataException)
                {
                }
            }

            context.Database.ExecuteSqlCommand("ALTER TABLE [Shopy].[dbo].[User] ADD CONSTRAINT uq_user_username UNIQUE(username)");

            base.Seed(context);
        }
    }
}
