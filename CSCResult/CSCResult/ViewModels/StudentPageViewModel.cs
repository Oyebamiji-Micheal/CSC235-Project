using CSCResult.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using CSCResult.Views;
using CSCResult.Models;
using System.Collections.ObjectModel;

namespace CSCResult.ViewModels
{
    public class StudentPageViewModel : BaseViewModel
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

        private string _Name;
        public string Name
        {
            set
            {
                _Name = value;
                OnPropertyChanged();
            }

            get
            {
                return _Name;
            }
        }

        private string _Level;
        public string Level
        {
            set
            {
                _Level = value;
                OnPropertyChanged();
            }

            get
            {
                return _Level;
            }
        }

        private string _AdmissionCategory;
        public string AdmissionCategory
        {
            set
            {
                _AdmissionCategory = value;
                OnPropertyChanged();
            }

            get
            {
                return _AdmissionCategory;
            }
        }

        // public ObservableCollection<StudentProfile> VarStudentProfile { get; set; }

        public Command LogoutCommand { get; set; }

        public StudentPageViewModel()
        {
            var matric_no = Preferences.Get("MatricNo", String.Empty);
            MatricNo = matric_no;

            var name = Preferences.Get("Name", String.Empty);
            Name = name;

            var level = Preferences.Get("Level", String.Empty);
            Level = level;

            var admission_category = Preferences.Get("AdmissionCategory", String.Empty);
            AdmissionCategory = admission_category;
            
            LogoutCommand = new Command(async () => await LogoutAsync());
        }

        private async Task LogoutAsync()
        {
            Preferences.Remove("MatricNo");
            Preferences.Remove("Name");
            Preferences.Remove("Level");
            Preferences.Remove("AdmissionCategory");
            await Application.Current.MainPage.Navigation.PushModalAsync(new StudentLogin());
        }
    }
}