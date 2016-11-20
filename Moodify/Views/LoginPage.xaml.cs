using Moodify.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Moodify.Views
{
    public partial class LoginPage : ContentPage
    {
        public static string userName { get; set; }
        public static string eMail { get; set; }

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
                List<JsonUserModel> x = await AzureManager.AzureManagerInstance.GetDetails();

                foreach (JsonUserModel y in x)
                {
                    if (Username.Text.Equals(y.UserName) && Password.Text.Equals(y.Password))
                    {
                       
                        App.isLogin = true;
                        App.RootPage.Master.IsVisible = true;
                        userName = y.UserName;
                        eMail = y.Email;
                        App.RootPage.Detail = new NavigationPage(new HomePage());
                        break;
                    }
                }
                if(App.isLogin == false)
                await DisplayAlert("Invalid Username or Password", "Incorrect username or password", "Ok");
            }
        }
    }

    }

       


