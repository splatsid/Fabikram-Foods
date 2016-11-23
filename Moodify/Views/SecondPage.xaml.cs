using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Moodify.ViewModels;
using Fabikram.Views;
using Moodify.DataModels;
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
                var action = await DisplayActionSheet("Send to", "Return", null, "Cart", "Favourites");
                listView.SelectedItem = null;

                switch (action)
                {
                    case "Cart":
                        ListViewData.CartList.Add(s);
                        break;
                    case "Favourites":
                        List<JsonUserModel> z = await AzureManager.AzureManagerInstance.GetDetails();
                        foreach (JsonUserModel temp in z)
                        {
                            if (temp.UserName.Equals(LoginPage.userName))
                            {
                                if(temp.Favourites == null)
                                {
                                    temp.Favourites = "";
                                }
                                if (!temp.Favourites.Contains(s.easyName))
                                {
                                    temp.Favourites += (temp.Favourites + s.easyName + " ");
                                    await AzureManager.AzureManagerInstance.Update(temp);
                                    await DisplayAlert("Added", (s.name + " Was added to your favourites!"), "Return");
                                }else
                                {
                                    await DisplayAlert("Already Exists", (s.name + " Already exists in your favourites!"), "Return");

                                }

                                break;
                            }
                        }
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
