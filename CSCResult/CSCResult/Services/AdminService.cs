using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;

using Xamarin.Forms.Xaml;
using CSCResult.Models;

namespace CSCResult.Services
{
    class AdminService
    {
        FirebaseClient client;

        public AdminService()
        {
            client = new FirebaseClient("https://cscresultapp-default-rtdb.firebaseio.com");
        }

        public async Task<bool> IsAdminExists(string email)
        {
            var admin = (await client.Child("Admins")
                .OnceAsync<Admin>()).Where(u => u.Object.Email == email).FirstOrDefault();

            return (admin != null);
        }

        public async Task<bool> RegisterAdmin(string email, string passwd)
        {
            if (await IsAdminExists(email) == false)
            {
                await client.Child("Admins")
                    .PostAsync(new Admin()
                    {
                        Email = email,
                        Password = passwd
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginAdmin(string email, string passwd)
        {
            var admin = (await client.Child("Admins")
                .OnceAsync<Admin>()).Where(u => u.Object.Email == email)
                .Where(u => u.Object.Password == passwd).FirstOrDefault();
            return (admin != null);
        }
    }
}
