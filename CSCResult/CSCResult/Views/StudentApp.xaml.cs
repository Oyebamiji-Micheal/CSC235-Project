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
    public partial class StudentApp : ContentPage
    {
        public StudentApp()
        {
            InitializeComponent();
        }

        async public void StudentLogin_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new StudentLogin());
        }
    }
}