using Android.Locations;
using Fabikram.DataModels;
using Fabikram.Views;
using Moodify.DataModels;
using Moodify.Views;
using Newtonsoft.Json;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;

namespace Moodify
{
	public partial class HomePage : ContentPage
	{
        public static RootObject stats { get; set; }
		public HomePage()
		{
            BindingContext = new MenuPageViewModel();
            Title = "Menu";
            InitializeComponent();
            HeadTitle.Text = "Welcome to Fabikram Foods " + LoginPage.userName;
            System.Diagnostics.Debug.WriteLine(LoginPage.userName);
           
            if (stats == null)
            {
                getLoc();
            }else
            {
              Location.Text = "You are " + stats.rows[0].elements[0].distance.text + " away from our Restaurant!, it is approximately " + stats.rows[0].elements[0].duration.text + " away";
              
            }
        } 

        public async void getLoc()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 2;
            try
            {
 
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                var httpClient = new HttpClient();
                var url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins=" + position.Latitude + "," + position.Longitude + "&destinations=Wynyard+Quarter,Auckland&" + "key=AIzaSyCdo0qsVkRaSC_gwy34N_IzjS2E-4rnvhU";
                var userJson = await httpClient.GetStringAsync(url);
                JsonTextReader reader = new JsonTextReader(new StringReader(userJson));
                stats = JsonConvert.DeserializeObject<RootObject>(userJson);
                Location.Text = "You are " + stats.rows[0].elements[0].distance.text+ " away from our Restaurant, it is approximately "+ stats.rows[0].elements[0].duration.text + " away";

            }
            catch (Exception e){
                Location.Text = "";
            }
        }

        public void GoSecond(object Sender, EventArgs a)
        {
            App.RootPage.Detail = new TabbedPage { Children = { new SecondPage(), new TabbedPageMeals() } };
        }

        public void GoAbout(object Sender, EventArgs a)
        {
            App.RootPage.Detail = new NavigationPage(new About());
            App.MenuIsPresented = false;
        }

        public void GoFavourites(object Sender, EventArgs a)
        {
            App.RootPage.Detail = new NavigationPage(new Favourites());
        }
    }
}
