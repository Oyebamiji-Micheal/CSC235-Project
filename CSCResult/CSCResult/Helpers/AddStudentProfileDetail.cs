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
    public class AddStudentProfileDetail
    {
        public List<StudentProfile> StudentProfiles { get; set; }

        FirebaseClient client;

        public AddStudentProfileDetail()
        {
            client = new FirebaseClient("https://cscresultapp-default-rtdb.firebaseio.com");
            StudentProfiles = new List<StudentProfile>()
            {
                new StudentProfile()
                {
                    ProfileId = 1,
                    MatricNo = "222497",
                    Name = "Ojo Peter",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 2,
                    MatricNo = "222483",
                    Name = "Micheal Israel",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 3,
                    MatricNo = "223765",
                    Name = "Adesola Samuel",
                    Level = "200",
                    AdmissionCategory = "DE"
                },
                new StudentProfile()
                {
                    ProfileId = 4,
                    MatricNo = "230872",
                    Name = "Adedire Victoria",
                    Level = "200",
                    AdmissionCategory = "DE"
                },
                new StudentProfile()
                {
                    ProfileId = 5,
                    MatricNo = "222451",
                    Name = "Adedoyin Olateju",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 6,
                    MatricNo = "222512",
                    Name = "Salaudeen Adebayo",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 7,
                    MatricNo = "222470",
                    Name = "Chris-Odeh Tobechukwu",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 8,
                    MatricNo = "230901",
                    Name = "Ibeh Mary",
                    Level = "200",
                    AdmissionCategory = "DE"
                },
                new StudentProfile()
                {
                    ProfileId = 9,
                    MatricNo = "222457",
                    Name = "Ajobola Samuel",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 10,
                    MatricNo = "230868",
                    Name = "Adebayo Muyideen",
                    Level = "200",
                    AdmissionCategory = "DE"
                },
                new StudentProfile()
                {
                    ProfileId = 11,
                    MatricNo = "222513",
                    Name = "Shonubi Samuel",
                    Level = "200",
                    AdmissionCategory = "DE"
                },
                new StudentProfile()
                {
                    ProfileId = 12,
                    MatricNo = "222474",
                    Name = "Fakolade Ifeoluwa",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 13,
                    MatricNo = "222479",
                    Name = "Joseph Miracle",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 14,
                    MatricNo = "222450",
                    Name = "Adebayo AbdlBasir",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
                new StudentProfile()
                {
                    ProfileId = 15,
                    MatricNo = "123456",
                    Name = "A Bot",
                    Level = "200",
                    AdmissionCategory = "Regular"
                },
            };
        }
         
        public async Task AddStudentProfileDetailAsync()
        {
            try
            {
                foreach (var profile in StudentProfiles)
                {
                    await client.Child("StudentProfiles").PostAsync(new StudentProfile()
                    {
                        ProfileId = profile.ProfileId,
                        MatricNo = profile.MatricNo,
                        Name = profile.Name,
                        Level = profile.Level,
                        AdmissionCategory = profile.AdmissionCategory
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
