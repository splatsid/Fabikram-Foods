using Moodify;
using Moodify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabikram.Views
{
    public partial class TabbedPageMeals : ContentPage
    {
        public TabbedPageMeals()
        {
            InitializeComponent();
            listView.ItemsSource = ListViewData.ProductList;

        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs a)
        {
            if (a.SelectedItem != null)
            {
                var s = a.SelectedItem as Product;
                var action = await DisplayActionSheet("Send to", "Return", null, "Cart", "Favourites");

                switch (action)
                {
                    case "Cart":
                        ListViewData.CartList.Add(s);
                        break;
                    case "Favourites":
                        ListViewData.addToFavourites(s);
                        break;
                }

            }
        }

        private void GoHome(object sender, EventArgs a)
        {
            App.RootPage.Detail = new NavigationPage(new HomePage());
        }

        private void GoCart(object sender, EventArgs a)
        {
            App.RootPage.Detail = new NavigationPage(new Cart());
        }
    }
}
