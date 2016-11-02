using Shopy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Logic.Interface.DataAccess
{
    public interface IUserRepository
    {
        Task AddUser(ShopingList shopingList);
        Task<IEnumerable<User>> GetUsers(ShopingList shopingList);
        Task<User> CheckUser(string username, string pwhash);
    }
}
