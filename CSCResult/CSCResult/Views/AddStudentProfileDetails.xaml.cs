using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CSCResult.Helpers;

namespace CSCResult.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStudentProfileDetails : ContentPage
    {
        public AddStudentProfileDetails()
        {
            InitializeComponent();
        }

        async void ButtonAddProfile_Clicked(System.Object sender, System.EventArgs e)
        {
            var add_student = new AddStudentProfileDetail();
            await add_student.AddStudentProfileDetailAsync();
        }
    }
}