using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shopy.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //var list = new DataService().GetShopingList().Result;
            //this.lbl.Text = list.ShopingItems.FirstOrDefault()?.Product?.Productname;
        }
    }
}
