using Fabikram.Views;
using Moodify.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Moodify
{
	public class MenuPageViewModel : ContentPage
	{
       
		public ICommand GoHomeCommand { get; set; }
		public ICommand GoSecondCommand { get; set; }
        public ICommand GoAboutCommand { get; set; }
        public ICommand GoLocationCommand { get; set; }
        public ICommand GoCartCommand { get; set; }
        public MenuPageViewModel()
		{
			GoHomeCommand = new Command(GoHome);
			GoSecondCommand = new Command(GoSecond);
            GoLocationCommand = new Command(GoLocation);
            GoCartCommand = new Command(GoCart);
        }

		void GoHome(object obj)
		{
            if (App.isLogin)
            {
                App.RootPage.Detail = new NavigationPage(new HomePage());
                App.MenuIsPresented = false;
            }else
            {
                DisplayAlert("Not Logged in", "Please log in", "Ok");
            }
		}

		void  GoSecond(object obj)
		{
            if (App.isLogin)
            {
                App.RootPage.Detail = new TabbedPage { Children = { new SecondPage(), new TabbedPageMeals() } };
                App.MenuIsPresented = false;                
            }
            else
            {
                DisplayAlert("Not Logged in", "Please log in", "Ok");
            }
        }

     
        void GoLocation(Object obj)
        {
            if (App.isLogin)
            {
                App.RootPage.Detail = new NavigationPage(new LocationPage());
                App.MenuIsPresented = false;
            }
            else
            {
                DisplayAlert("Not Logged in", "Please log in", "Ok");
            }
        }

       void GoCart(Object obj)
        {
            App.RootPage.Detail = new NavigationPage(new Cart());
            App.MenuIsPresented = false;
        }


    }
}
