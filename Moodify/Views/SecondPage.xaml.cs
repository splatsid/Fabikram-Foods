using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Moodify.ViewModels;

namespace Moodify
{
	public partial class SecondPage : ContentPage
	{
        public SecondPage()
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
		}
	}
