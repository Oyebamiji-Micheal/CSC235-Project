using CSCResult.Models;
using CSCResult.ViewModels;
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
    public partial class AddUpdateCourse : ContentPage
    {
        public AddUpdateCourse()
        {
            InitializeComponent();
            this.BindingContext = new AddUpdateCoursePageViewModel();
        }

        public AddUpdateCourse(StudentCoursesModel course)
        {
            InitializeComponent();
            this.BindingContext = new AddUpdateCoursePageViewModel(course);
        }
    }
}