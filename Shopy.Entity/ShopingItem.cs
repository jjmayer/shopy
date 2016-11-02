using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Entity
{
    public class ShopingItem : Entity
    {
        [MaxLength(200, ErrorMessage = "The length of the note must not be longer than 200 characters")]
        public string Note { get; set; }
        public bool Priority { get; set; }
        public bool Done { get; set; }
        /// <summary>
        /// Describing the quantity required for this entry, string because values expected are e.g. 200dg, 1x, ...
        /// </summary>
        [MaxLength(50, ErrorMessage = "The qunatity description of the note must not be longer than 50 characters")]
        public string QuantityDescription { get; set; }

        [Required]
        public string ShopingListId { get; set; }
        public virtual ShopingList ShopingList { get; protected set; }
        [Required]
        public string UserId { get; set; }
        public virtual User User { get; protected set; }
        [Required]
        public string ProductId { get; set; }
        public virtual Product Product { get; protected set; }
        public string ShopId { get; set; }
        public virtual Shop Shop { get; protected set; }
        public string ImageId { get; set; }
        public virtual Image Image { get; protected set; }
    }
}
