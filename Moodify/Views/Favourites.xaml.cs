using Moodify.DataModels;
using Moodify.ViewModels;
using Moodify.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabikram.Views
{
    public partial class Favourites : ContentPage
    {
        public Favourites()
        {
            InitializeComponent();
            listView.ItemsSource = ListViewData.FavouriteList;
            

        }


        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs a)
        {

            if (a.SelectedItem != null)
            {
                var s = a.SelectedItem as Product;
                var x = await DisplayActionSheet("Action", "Ok", null, "Add to Cart", "Remove From Favourites");
                listView.SelectedItem = null;

                switch (x)
                {
                    case "Remove From Favourites":
                        ListViewData.FavouriteList.Remove(s);
                        String p = "";
                        foreach(Product z in ListViewData.FavouriteList)
                        {
                            p += z.easyName + " ";
                        }
                        LoginPage.usermodel.Favourites = p;
                        await AzureManager.AzureManagerInstance.Update(LoginPage.usermodel);

                        break;
                    case "Add to Cart":
                        ListViewData.CartList.Add(s);
                        break;
                }
            }
        }

  
    }
}

   
    
