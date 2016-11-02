using Newtonsoft.Json;
using Shopy.App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.App
{
    public class DataService
    {
        public async Task<Shopy.App.Entity.ShopingList> GetShopingList()
        {
            var client = new System.Net.Http.HttpClient();
            //client.BaseAddress = new Uri("http://localhost:5000/", UriKind.Absolute);
            client.DefaultRequestHeaders.Add("user", "Admin");
            client.DefaultRequestHeaders.Add("pw", "d033e22ae348aeb5660fc2140aec35850c4da997");
            var res = await client.GetAsync("http://localhost:5000/api/shopinglist");

            res.EnsureSuccessStatusCode();
            var json = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ShopingList>(json);
        }
    }
}
