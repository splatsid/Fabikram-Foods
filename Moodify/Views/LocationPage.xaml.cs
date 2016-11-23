using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Moodify.Views
{
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {

            InitializeComponent();
            var map = new Map();
            MapSpan ms = new MapSpan(new Xamarin.Forms.Maps.Position(0, 0), 360, 360);
            map.MoveToRegion(ms);
            map.VerticalOptions = LayoutOptions.FillAndExpand;
            map.IsShowingUser = true;

            Content = map;
        }
    }
}
