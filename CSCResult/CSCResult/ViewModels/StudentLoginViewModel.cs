using CSCResult.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using CSCResult.Views;

namespace CSCResult.ViewModels
{
    public class StudentLoginViewModel : BaseViewModel
    {
        private string _MatricNo;
        public string MatricNo
        {
            set
            {
                this._MatricNo = value;
                OnPropertyChanged();
            }
            get
            {
                return this._MatricNo;
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return this._IsBusy;
            }
        }

        private bool _Result;
        public bool Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public StudentLoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var studentService = new StudentService();
                Result = await studentService.RegisterStudent(MatricNo, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Sucess", "Student Registered Successfully", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error",
                        "Student already exists with this credentials", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy) 
                return;
            try
            {
                IsBusy = true;
                var studentService = new StudentService();
                Result = await studentService.LoginStudent(MatricNo, Password);
                if (Result)
                {
                    Preferences.Set("MatricNo", MatricNo);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new StudentPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Matric No or Password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
