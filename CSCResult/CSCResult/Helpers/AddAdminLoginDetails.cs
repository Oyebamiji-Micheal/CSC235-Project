using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSCResult.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using CSCResult.Services;

using Xamarin.Essentials;
using Xamarin.Forms;
using CSCResult.Views;

namespace CSCResult.Helpers
{
    class AddAdminLoginDetails
    {
        public List<Admin> Admins { get; set; }
        FirebaseClient client;

        public AddAdminLoginDetails()
        {
            client = new FirebaseClient("https://cscresultapp-default-rtdb.firebaseio.com");
            Admins = new List<Admin>()
            {
                new Admin()
                {
                    Email = "statistics@gmail.com",
                    Password = "statistics"
                },
                new Admin()
                {
                    Email = "mathematics@gmail.com",
                    Password = "mathematics"
                },
                new Admin()
                {
                    Email = "ges@gmail.com",
                    Password = "ges"
                },
                new Admin()
                {
                    Email = "computerscience@gmail.com",
                    Password = "computerscience"
                },
            };
        }

        public async Task AddAdminAsync()
        {
            try
            {
                foreach (var admin in Admins)
                {
                    await client.Child("Admins").PostAsync(new Admin()
                    {
                        Email = admin.Email,
                        Password = admin.Password
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
