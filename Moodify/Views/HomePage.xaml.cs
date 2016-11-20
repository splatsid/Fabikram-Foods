using Moodify.DataModels;
using Moodify.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Moodify
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
            BindingContext = new MenuPageViewModel();
            Title = "Menu";
            InitializeComponent();
            HeadTitle.Text = "Welcome to Fabikram Foods " + LoginPage.userName;
            System.Diagnostics.Debug.WriteLine(LoginPage.userName);

        }
    }
}
