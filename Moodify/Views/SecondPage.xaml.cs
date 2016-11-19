using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Moodify.Views;

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
                await DisplayAlert("Order Placed", "You have Ordered " + s.name , "ok");
                
            }
        }
		}
	}
