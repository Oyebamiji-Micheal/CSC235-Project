using CSCResult.Models;
using CSCResult.Services.Interfaces;
using CSCResult.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using Xamarin.Essentials;

namespace CSCResult.ViewModels
{
    public class CourseListPageViewModel : BaseViewModel
    {
        #region Properties
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private readonly ICourseService _studentCourseService;

        public ObservableCollection<StudentCoursesModel> Courses { get; set; } = new ObservableCollection<StudentCoursesModel>();
        #endregion

        #region Constructor
        public CourseListPageViewModel()
        {
            _studentCourseService = DependencyService.Resolve<ICourseService>();
            GetAllCourses();
        }
        #endregion

        #region Methods
        private void GetAllCourses()
        {
            IsBusy = true;
            Task.Run(async () =>
            {
                var courseList = await _studentCourseService.GetAllCourses();
                Device.BeginInvokeOnMainThread(() =>
                {

                    Courses.Clear();
                    if (courseList?.Count > 0)
                    {
                        foreach (var course in courseList)
                        {
                            Courses.Add(course);
                        }
                    }
                    IsBusy = IsRefreshing = false;
                });

            });
        }
        #endregion

        #region Commands

        public ICommand RefreshCommand => new Command(() =>
        {
            IsRefreshing = true;
            GetAllCourses();
        });

        public ICommand SelectedCourseCommand => new Command<StudentCoursesModel>(async (course) =>
        {
            if (course != null)
            {
                var response = await App.Current.MainPage.DisplayActionSheet("Options!", "Cancel", null, "Update Course", "Delete Course");

                if (response == "Update Course")
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddUpdateCourse(course));
                }
                else if (response == "Delete Course")
                {
                    IsBusy = true;
                    bool deleteResponse = await _studentCourseService.DeleteCourse(course.Key);
                    if (deleteResponse)
                    {
                        GetAllCourses();
                    }
                }
            }
        });
        #endregion
    }
}