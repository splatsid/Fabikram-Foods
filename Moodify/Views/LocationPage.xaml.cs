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

            Map map = new Map(MapSpan.FromCenterAndRadius(new Position(200, 200), Distance.FromKilometers(0.5)));
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(200, 200), Distance.FromKilometers(1)));
            
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) => {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };
        }
    }
}
