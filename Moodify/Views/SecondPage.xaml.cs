using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Moodify.Views;

namespace Moodify
{
	public partial class SecondPage : ContentPage
	{
		public SecondPage()
		{
			InitializeComponent();
            listView.ItemsSource = ListViewData.ProductList;
		}
	}
}
