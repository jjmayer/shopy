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
    public sealed class UserRepository : IUserRepository
    {
        public Task AddUser(ShopingList shopingList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers(ShopingList shopingList)
        {
            throw new NotImplementedException();
        }

        public async Task<User> CheckUser(string username, string pwhash)
        {
            using (var ctx = new ShopyContext())
            {
                return await (from u in ctx.Users
                       where u.Username == username
                          && u.PasswordHash == pwhash
                       select u).SingleOrDefaultAsync().ConfigureAwait(false);
            }
        }
    }
}
