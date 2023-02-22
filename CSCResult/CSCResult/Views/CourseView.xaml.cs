using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CSCResult.Views;

using System.ComponentModel;

namespace CSCResult.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
    {
        public CourseView()
        {
            InitializeComponent();
        }
        private void AddCourse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddUpdateCourse());
        }

        private void ShowCourse_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseList());
        }
    }
}