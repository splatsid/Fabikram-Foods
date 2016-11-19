using Moodify.Views;
using Xamarin.Forms;

namespace Moodify
{
	public partial class App : Application
	{
		
		public static NavigationPage NavigationPage { get; private set; }
		public static RootPage RootPage;
        public static bool isLogin = false;
		public static bool MenuIsPresented
		{
			get
			{
				return RootPage.IsPresented;
			}
			set
			{
				RootPage.IsPresented = value;
			}
		}

		public App()
		{
			var menuPage = new MenuPage();
            var login = new LoginPage();
			NavigationPage = new NavigationPage(new LoginPage());
			RootPage = new RootPage();
			RootPage.Master = menuPage;
			RootPage.Detail = NavigationPage;
			MainPage = RootPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
