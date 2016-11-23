using Fabikram.Views;
using Moodify.DataModels;
using Moodify.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Moodify.Views
{
    public partial class LoginPage : ContentPage
    {
        public static string userName { get; set; }
        public static string eMail { get; set; }
        public static JsonUserModel usermodel { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            Password.IsPassword = true;
        }


        private void Signup_Clicked(object sender, EventArgs args)
        {
            App.RootPage.Detail = new NavigationPage(new SignUp());
        }

        private async void LoginClicked(Object sender, EventArgs args)
        {
            if (Username.Text == null | Password.Text == null)
            {
                await DisplayAlert("Invalid Username or Password", "Incorrect username or password", "Ok");

            }
            else
            {
                Activity.IsRunning = true;

                List<JsonUserModel> x = await AzureManager.AzureManagerInstance.QueryLogin(Username.Text);

                if (x.Count == 0)
                {
                    if (App.isLogin == false)
                        await DisplayAlert("Invalid Username or Password", "Incorrect username or password", "Ok");
                    Activity.IsRunning = false;
                }else if (!x[0].Password.Equals(Password.Text))
                {
                    if (App.isLogin == false)
                        await DisplayAlert("Invalid Username or Password", "Incorrect username or password", "Ok");
                    Activity.IsRunning = false;
                }else
                {
                    Activity.IsRunning = false;
                    App.RootPage.Detail = new NavigationPage(new HomePage());
                    App.isLogin = true;
                    App.RootPage.Master.IsVisible = true;
                    userName =Username.Text;
                    usermodel = x[0];
                    ListViewData.populateHashMap();
                    checkFavs();
                }

                

     
            
            }
        }

        public static async void checkFavs()
        {
            if (ListViewData.FavouriteList.Count == 0)
            {
                List<JsonUserModel> x = await AzureManager.AzureManagerInstance.QueryLogin(LoginPage.userName);
             
                    if (x[0].Favourites != null && x[0].Favourites != "")
                    {
                        x[0].Favourites = x[0].Favourites.TrimEnd();
                        String[] favsplit = x[0].Favourites.Split();
                        foreach (String z in favsplit)
                        {
                        Product temp = new Product();
                        ListViewData.totalproductlist.TryGetValue(z, out temp);
                        if(temp.easyName != null)
                        ListViewData.addToFavourites(temp);
                        }
                    }
                
            }
        }

        private  void FacebookLogin(Object sender, EventArgs a)
        {
            App.RootPage.Detail = new NavigationPage(new Page1());

        }
        public static string FirstCharToUpper(string str)
        {
            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }



}

       


