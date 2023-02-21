using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;

using Xamarin.Forms.Xaml;
using CSCResult.Models;
using System.Collections.ObjectModel;
using CSCResult.Views;

namespace CSCResult.Services
{
    public class StudentCoursesService
    {
        FirebaseClient client;
        public StudentCoursesService()
        {
            client = new FirebaseClient("https://cscresultapp-default-rtdb.firebaseio.com");
        }
    }
}
