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
    public partial class CourseList : ContentPage
    {
        public CourseList()
        {
            InitializeComponent();
        }
        async public void AddCourse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddUpdateCourse());
        }
    }
}