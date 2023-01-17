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
    public class AdminLoginViewModel : BaseViewModel
    {
        private string _Email;
        public string Email
        {
            set
            {
                this._Email = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Email;
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

        public AdminLoginViewModel()
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
                var adminService = new AdminService();
                Result = await adminService.RegisterAdmin(Email, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Sucess", "Admin Registered Successfully", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error",
                        "Admin already exists with this credentials", "OK");
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
                var adminService = new AdminService();
                Result = await adminService.LoginAdmin(Email, Password);
                if (Result)
                {
                    Preferences.Set("Email", Email);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new AdminPage());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Email or Password", "OKs");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OKy");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
