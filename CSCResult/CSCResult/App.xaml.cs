using CSCResult.Views;
using System;
using Xamarin.Forms;

namespace CSCResult
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            // MainPage = new NavigationPage(new AddLoginDetails());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
