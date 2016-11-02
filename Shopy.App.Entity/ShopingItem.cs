using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.App.Entity
{
    public class ShopingItem : Entity
    {
        public string Note { get; set; }
        public bool Priority { get; set; }
        public bool Done { get; set; }
        /// <summary>
        /// Describing the quantity required for this entry, string because values expected are e.g. 200dg, 1x, ...
        /// </summary>
        public string QuantityDescription { get; set; }

        public string ShopingListId { get; set; }
        public virtual ShopingList ShopingList { get; protected set; }
        public string UserId { get; set; }
        public virtual User User { get; protected set; }
        public string ProductId { get; set; }
        public virtual Product Product { get; protected set; }
        public string ShopId { get; set; }
        public virtual Shop Shop { get; protected set; }
        public string ImageId { get; set; }
        public virtual Image Image { get; protected set; }
    }
}
