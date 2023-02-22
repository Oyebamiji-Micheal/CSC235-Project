using Xamarin.Forms.Xaml;
using CSCResult.Views;
using System;
using Xamarin.Forms;
using CSCResult.Services.Implementations;
using CSCResult.Services.Interfaces;

namespace CSCResult
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            // MainPage = new NavigationPage(new AddLoginDetails());
            // MainPage = new NavigationPage(new AddStudentProfileDetails());
            // MainPage = new NavigationPage(new CourseList());
            // MainPage = new NavigationPage(new AddCourse());
            // MainPage = new NavigationPage(new StudentPage());
            DependencyService.Register<ICourseService, StudentCoursesService>();
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
