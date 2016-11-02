using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Entity
{
    public class User : Entity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The length of the username must not exceed 50 characters")]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string ShopingListId { get; set; }
        [ForeignKey("ShopingListId")]
        public virtual ShopingList ShopingList { get; protected set; }
    }
}
