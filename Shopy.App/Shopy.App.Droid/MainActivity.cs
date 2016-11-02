using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Android.Net.Http;
using Xamarin.Android.Net;

namespace Shopy.App.Droid
{
    [Activity(Label = "Shopy.App", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnStart()
        {
            var x = GetShopingList().Result;
            base.OnStart();
        }

        public async Task<Shopy.App.Entity.ShopingList> GetShopingList()
        {
            var client = new System.Net.Http.HttpClient(new AndroidClientHandler());
            //client.BaseAddress = new Uri("http://localhost:5000/", UriKind.Absolute);
            client.DefaultRequestHeaders.Add("user", "Admin");
            client.DefaultRequestHeaders.Add("pw", "d033e22ae348aeb5660fc2140aec35850c4da997");
            var res = await client.GetAsync("http://localhost:5000/api/shopinglist");

            res.EnsureSuccessStatusCode();
            var json = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Shopy.App.Entity.ShopingList>(json);
        }
    }
}

