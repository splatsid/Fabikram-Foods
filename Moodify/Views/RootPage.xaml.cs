using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Moodify
{
	public partial class RootPage : MasterDetailPage
	{
		public RootPage()
		{
			InitializeComponent();
            if(App.isLogin)
			MasterBehavior = MasterBehavior.Popover;
		}


	}
}
