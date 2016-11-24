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
        public ICommand GoFavouritesCommand { get; set; }
        public ICommand GoLoginCommand { get; set; }
        public MenuPageViewModel()
		{
			GoHomeCommand = new Command(GoHome);
			GoSecondCommand = new Command(GoSecond);
            GoCartCommand = new Command(GoCart);
            GoFavouritesCommand = new Command(GoFavourites);
            GoAboutCommand = new Command(GoAbout);
            GoLoginCommand = new Command(Logout);
        }

        void GoAbout(Object obj)
        {
            App.RootPage.Detail = new NavigationPage(new About());
            App.MenuIsPresented = false;
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
                App.RootPage.Detail = new TabbedPage { Children = { new SecondPage()  , new TabbedPageMeals()  } };
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


        void GoFavourites(Object obj)
        {
            App.RootPage.Detail = new NavigationPage(new Favourites());
            App.MenuIsPresented = false;
        }

        void Logout(Object obj)
        {
            App.RootPage.Detail = new NavigationPage(new LoginPage());
            App.RootPage.Master = new Default();
            App.MenuIsPresented = false;
            App.isLogin = false;
        }

    }
}
