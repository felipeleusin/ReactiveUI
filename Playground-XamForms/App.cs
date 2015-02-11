using System;
using Xamarin.Forms;

namespace PlaygroundXamForms
{
    public class App : Application
	{
		public static Page GetMainPage ()
		{	
            return new MainPage();
		}
	}
}

