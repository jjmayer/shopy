using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.App.Entity
{
    public class ShopingList : Entity
    {
        public ShopingList()
        {
            this.Users = new HashSet<User>();
            this.ShopingItems = new HashSet<ShopingItem>();
        }

        public DateTime? Finished { get; set; }

        public string PriorShopingListId { get; set; }
        public virtual ShopingList PriorShopingList { get; set; }
        public virtual ShopingList ChildShoppingList { get; set; }
        public virtual ICollection<User> Users { get; protected set; }
        public virtual ICollection<ShopingItem> ShopingItems { get; protected set; }
    }
}
