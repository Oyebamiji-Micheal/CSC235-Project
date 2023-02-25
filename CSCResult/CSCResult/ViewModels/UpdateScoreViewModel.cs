using CSCResult.Models;
using CSCResult.Services.Implementations;
using CSCResult.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace CSCResult.ViewModels
{
    public class UpdateScoreViewModel : BaseViewModel
    {
        private string _MatricNo;
        public string MatricNo
        {
            set
            {
                _MatricNo = value;
                OnPropertyChanged();
            }

            get
            {
                return _MatricNo;
            }
        }

        public List<string> EmailOptions { get; set; } = new List<string> { "mathematics@gmail.com", "statistics@gmail.com", "ges@gmail.com", "computerscience@gmail.com", "physics@gmail.com" };

        #region Properties
        private readonly IAdminService _studentCourseService;

        private StudentCoursesModel _courseDetail = new StudentCoursesModel();
        public StudentCoursesModel CourseDetail
        {
            get => _courseDetail;
            set => SetProperty(ref _courseDetail, value);
        }
        #endregion

        #region Constructor
        public UpdateScoreViewModel()
        {

            _studentCourseService = DependencyService.Resolve<IAdminService>();
        }

        public UpdateScoreViewModel(StudentCoursesModel studentResponse)
        {
            _studentCourseService = DependencyService.Resolve<IAdminService>();
            CourseDetail = new StudentCoursesModel
            {
                CourseCode = studentResponse.CourseCode,
                CourseDescription = studentResponse.CourseDescription,
                Key = studentResponse.Key,
                CourseUnit = studentResponse.CourseUnit,
                AdminEmail = studentResponse.AdminEmail,
                Score = studentResponse.Score,
            };
        }
        #endregion

        #region Commands
        public ICommand SaveCourseCommand => new Command(async () =>
        {
            if (IsBusy) return;
            IsBusy = true;
            var matric_no = Preferences.Get("MatricNo", String.Empty);
            CourseDetail.MatricNo = matric_no;
            // CourseDetail.Score = 0;

            bool res = await _studentCourseService.UpdateScore(CourseDetail);
            if (res)
            {
                if (!string.IsNullOrWhiteSpace(CourseDetail.Key))
                {
                    await App.Current.MainPage.DisplayAlert("Success!", "Score Updated successfully.", "Ok");
                }
                else
                {
                    CourseDetail = new StudentCoursesModel() { };
                    await App.Current.MainPage.DisplayAlert("Success!", "Score Added successfully.", "Ok");
                }
            }
            IsBusy = false;
        });
        #endregion
    }
}