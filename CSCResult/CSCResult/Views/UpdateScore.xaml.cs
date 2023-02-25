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
    public partial class UpdateScore : ContentPage
    {
        public UpdateScore()
        {
            InitializeComponent();
            this.BindingContext = new UpdateScoreViewModel();
        }

        public UpdateScore(StudentCoursesModel course)
        {
            InitializeComponent();
            this.BindingContext = new UpdateScoreViewModel(course);
        }
    }
}