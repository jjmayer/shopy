using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.App.Entity
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public string ShopingListId { get; set; }
        public virtual ShopingList ShopingList { get; protected set; }
    }
}
