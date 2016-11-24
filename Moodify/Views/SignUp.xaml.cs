using Moodify.DataModels;
using System;
using Xamarin.Forms;
using PCLCrypto;

namespace Moodify.Views
{
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
            SPassword.IsPassword = true;
            RPassword.IsPassword = true;
        }
        public  void SignupClicked(object sender, EventArgs a)
        {
            if(SUsername.Text == null | Email.Text == null | SPassword.Text == null)
            {
                DisplayAlert("Invalid Details", "Please fill in all the forms", "Ok");
            }else if (SUsername.Text != "" && Email.Text!= "" && SPassword.Text!=""){
                if (SPassword.Text.Equals(RPassword.Text))
                {
                    App.RootPage.Detail = new NavigationPage(new LoginPage()) { BarBackgroundColor = Color.Black };
                    writeToDB();
                }else
                {
                     DisplayAlert("Invalid Password", "Passwords do not match", "Ok");
                }
            }else
            {
                 DisplayAlert("Invalid Details", "Please fill in all the forms", "Ok");
            }

        }

        public void ReturnToLogin(object sender, EventArgs a)
        {
            App.RootPage.Detail = new NavigationPage(new LoginPage());
        }

        public async void writeToDB()
        {


            JsonUserModel details = new JsonUserModel()
            {
                UserName = SUsername.Text,
                Email = Email.Text,
                Password = SPassword.Text
            };
            await AzureManager.AzureManagerInstance.AddDetails(details);
            SUsername.Text = "";
            Email.Text = "";
            SPassword.Text = "";
            RPassword.Text = "";
        }
    }
}
