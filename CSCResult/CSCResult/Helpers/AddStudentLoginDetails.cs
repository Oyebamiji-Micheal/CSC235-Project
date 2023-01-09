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
    public class AddStudentLoginDetails
    {
        public List<Student> Students { get; set; }

        FirebaseClient client;

        public AddStudentLoginDetails()
        {
            client = new FirebaseClient("https://cscresultapp-default-rtdb.firebaseio.com");
            Students = new List<Student>()
            {
                new Student()
                {
                    MatricNo = "222497",
                    Password = "222497"
                },
                new Student()
                {
                    MatricNo = "222483",
                    Password = "222483"
                },
                new Student()
                {
                    MatricNo = "223765",
                    Password = "223765"
                },
                new Student()
                {
                    MatricNo = "230872",
                    Password = "230872"
                },
                new Student()
                {
                    MatricNo = "222451",
                    Password = "222451"
                },
                new Student()
                {
                    MatricNo = "222512",
                    Password = "222512"
                },
                new Student()
                {
                    MatricNo = "222470",
                    Password = "222470"
                },
                new Student()
                {
                    MatricNo = "230901",
                    Password = "230901"
                },
                new Student()
                {
                    MatricNo = "222457",
                    Password = "222457"
                },
                new Student()
                {
                    MatricNo = "230868",
                    Password = "230868"
                },
                new Student()
                {
                    MatricNo = "222513",
                    Password = "222513"
                },
                new Student()
                {
                    MatricNo = "222474",
                    Password = "222474"
                },
                new Student()
                {
                    MatricNo = "222479",
                    Password = "222479"
                },
                new Student()
                {
                    MatricNo = "222450",
                    Password = "222450"
                },
                new Student()
                {
                    MatricNo = "123456",
                    Password = "123456"
                },
            };
        }

        public async Task AddStudentAsync()
        {
            try
            {
                foreach(var student in Students)
                {
                    await client.Child("Students").PostAsync(new Student()
                    {
                        MatricNo = student.MatricNo,
                        Password = student.Password
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
