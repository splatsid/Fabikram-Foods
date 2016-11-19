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
        public LoginPage()
        {
            InitializeComponent();
        }


        private  void Signup_Clicked(object sender, EventArgs args)
        {
              App.RootPage.Detail = new NavigationPage(new SignUp());
        }

        private void LoginClicked(Object sender, EventArgs args)
        {
            App.RootPage.Detail = new NavigationPage(new SecondPage());
        }
    }


}
