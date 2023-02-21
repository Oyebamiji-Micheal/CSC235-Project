using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using Xamarin.Essentials;
using System.Linq;

using Xamarin.Forms.Xaml;
using CSCResult.Models;

namespace CSCResult.Services
{
    class StudentService
    {
        FirebaseClient client;

        public StudentService()
        {
            client = new FirebaseClient("https://cscresultapp-default-rtdb.firebaseio.com");
        }
        
        public async Task<bool> IsStudentExists(string matric_no)
        {
            var student = (await client.Child("Students")
                .OnceAsync<Student>()).Where(u => u.Object.MatricNo == matric_no).FirstOrDefault();

            return (student != null);
        }

        public async Task<bool> RegisterStudent(string matric_no, string passwd)
        {
            if( await IsStudentExists(matric_no) == false)
            {
                await client.Child("Students")
                    .PostAsync(new Student()
                    {
                        MatricNo = matric_no,
                        Password = passwd
                    });       
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginStudent(string matric_no, string passwd)
        {
            var student = (await client.Child("Students")
                .OnceAsync<Student>()).Where(u => u.Object.MatricNo == matric_no)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();

            var profile = (await client.Child("StudentProfiles")
                .OnceAsync<StudentProfile>()).Where(u => u.Object.MatricNo == matric_no);

            foreach (var stn in profile)
            {
                Console.WriteLine("Sinners in the hand of Angry God");
                Preferences.Set("Name", stn.Object.Name);
                Preferences.Set("Level", stn.Object.Level);
                Preferences.Set("AdmissionCategory", stn.Object.AdmissionCategory);
            }  

            return (student != null);
        }
    }
}
