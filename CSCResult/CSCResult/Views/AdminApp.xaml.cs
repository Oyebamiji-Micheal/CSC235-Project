using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSCResult.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminApp : ContentPage
    {
        public AdminApp()
        {
            InitializeComponent();
        }

        async public void AdminLogin_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AdminLogin());
        }
    }
}