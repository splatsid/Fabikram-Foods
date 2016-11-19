using Moodify.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Moodify
{
	public class MenuPageViewModel
	{
		public ICommand GoHomeCommand { get; set; }
		public ICommand GoSecondCommand { get; set; }
        public ICommand GoAboutCommand { get; set; }
        public ICommand GoLocationCommand { get; set; }
		public MenuPageViewModel()
		{
			GoHomeCommand = new Command(GoHome);
			GoSecondCommand = new Command(GoSecond);
            GoAboutCommand = new Command(GoAbout);
            GoLocationCommand = new Command(GoLocation);

        }

		void GoHome(object obj)
		{
            App.RootPage.Detail = new NavigationPage(new HomePage());
			App.MenuIsPresented = false;
		}

		void GoSecond(object obj)
		{
            App.RootPage.Detail = new NavigationPage(new SecondPage());
            App.MenuIsPresented = false;
		}

        void GoAbout(Object obj)
        {
            App.RootPage.Detail = new NavigationPage(new AboutPage());
            App.MenuIsPresented = false;
        }

        void GoLocation(Object obj)
        {
            App.RootPage.Detail = new NavigationPage(new LocationPage());
            App.MenuIsPresented = false;
        }
	}
}
