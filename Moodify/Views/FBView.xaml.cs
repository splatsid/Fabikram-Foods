using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;
using Fabikram.DataModels;
using Moodify.Views;
using Moodify;
using Moodify.DataModels;
using System.Collections.Generic;
using Moodify.ViewModels;

namespace Fabikram.Views
{
    public partial class Page1 : ContentPage
    {
        private String appID = "165942640479284";
        public Page1()
        {
            InitializeComponent();

            var requestFbAPI = "https://www.facebook.com/dialog/oauth?app_id=" + appID + "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

            var webView = new WebView
            {
                Source = requestFbAPI
            };

            webView.Navigated +=  onNavigation;

            Content = webView;


        }

        private async void onNavigation(Object sender, WebNavigatedEventArgs e)
        {
            var token = getToken(e.Url);

            if(token != "")
            {
                await GetFacebookProfile(token);
            }
        }

        public async Task GetFacebookProfile(String token)
        {
            var url = "https://graph.facebook.com/v2.7/me/" + "?fields=name" + "&access_token=" + token;

            var httpClient = new HttpClient();
            var userJson = await httpClient.GetStringAsync(url);
            JsonTextReader reader = new JsonTextReader(new StringReader(userJson));
            var result = JsonConvert.DeserializeObject<FaceBookView>(userJson);
            LoginPage.userName = result.name;
            App.isLogin = true;
            App.RootPage.Master.IsVisible = true;
            App.RootPage.Master.IsEnabled = true;
            App.RootPage.Detail = new NavigationPage(new HomePage()) ;
           
            List<JsonUserModel> x = await AzureManager.AzureManagerInstance.QueryLogin(result.name);
            if(x.Count == 0)
            {
                JsonUserModel details = new JsonUserModel()
                {
                    UserName = result.name
                };

                await AzureManager.AzureManagerInstance.AddDetails(details);
            }else
            {
                LoginPage.usermodel = x[0];
                ListViewData.populateHashMap();
                LoginPage.checkFavs();
            }
        }


        private string getToken(String url)
        {

            if(url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var t = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

                var token = t.Remove(t.IndexOf("&expires_in="));
                return token;
            }
            return string.Empty;
        }
       }
}
