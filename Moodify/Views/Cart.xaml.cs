using Moodify.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabikram.Views
{
    public partial class Cart : ContentPage
    {
        public Cart()
        {
            InitializeComponent();
            Double price = 0.0;
            listView.ItemsSource = ListViewData.CartList;
            foreach(Product y in ListViewData.CartList)
            {
                price += y.price;
            }

            priceView.Text = "Total Price: " + price.ToString();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs a)
        {
            
            if (a.SelectedItem != null)
            {
                var s = a.SelectedItem as Product;
                var x = await DisplayActionSheet("Action", "Ok", null, "Remove From Cart");

                switch (x)
                {
                    case "Remove From Cart":
                        ListViewData.CartList.Remove(s);
                        Double price = 0.0;
                        listView.ItemsSource = ListViewData.CartList;
                        foreach (Product y in ListViewData.CartList)
                        {
                            price += y.price;
                        }

                        priceView.Text = "Total Price: " + price.ToString();
                        break;
                }
            }
        }
        private  void OrderNow(Object sender, EventArgs a)
        {

        }
    }
}
