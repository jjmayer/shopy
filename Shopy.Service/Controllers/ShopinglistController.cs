using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopy.Entity;
using Shopy.Logic.Interface.DataAccess;
using Microsoft.Extensions.Primitives;
using Shopy.DataAccess;

namespace Shopy.Service.Controllers
{
    [Route("api/[controller]")]
    public class ShopinglistController : Controller
    {
        private IShopingListRepository ShopingListRepository { get; }
        private IUserRepository UserRepository { get; }

        public ShopinglistController(IShopingListRepository shopingListRepository, IUserRepository userRepository)
        {
            this.ShopingListRepository = shopingListRepository;
            this.UserRepository = userRepository;
        }

        private Task<User> GetCurrentUser()
        {
            StringValues oValues;
            string user, pwhash;
            if (ControllerContext.HttpContext.Request.Headers.TryGetValue("user", out oValues))
            {
                user = oValues.Single();
                if (ControllerContext.HttpContext.Request.Headers.TryGetValue("pw", out oValues))
                {
                    pwhash = oValues.Single();
                    return UserRepository.CheckUser(user, pwhash);
                }
            }

            return null;
        }
        
        [HttpGet]
        public async Task<ShopingList> GetCurrentShoppinglist()
        {
            return await this.ShopingListRepository
                .GetCurrentShopingList(
                    await GetCurrentUser().ConfigureAwait(false)
                )
            .ConfigureAwait(false);
        }
    }
}
