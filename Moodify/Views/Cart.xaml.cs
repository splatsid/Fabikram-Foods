using Fabikram.DataModels;
using Moodify.DataModels;
using Moodify.ViewModels;
using Moodify.Views;
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
        private async void OrderNow(Object sender, EventArgs a)
        {
            if (!ListViewData.CartList.Count.Equals(0)) 
            {
                Order order = new Order();
                order.User = LoginPage.userName;
                double price = 0;
                foreach(Product x in ListViewData.CartList)
                {
                    order.Contents += x.easyName + " ";
                    price += x.price;
                }
                order.Price = price;

                await OrderManager.OrderManagerInstance.AddDetails(order);
                await DisplayAlert("Complete", "Order Complete, Ready to pick up in 15 minutes", "Ok");
                ListViewData.CartList.Clear();
            }
        }
    }
}
