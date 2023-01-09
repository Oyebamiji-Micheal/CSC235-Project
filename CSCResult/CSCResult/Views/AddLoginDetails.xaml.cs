using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CSCResult.Helpers;

namespace CSCResult.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddLoginDetails : ContentPage
	{
		public AddLoginDetails ()
		{
			InitializeComponent ();
		}

		async void ButtonStudents_Clicked(System.Object sender, System.EventArgs e)
		{
			var add_student = new AddStudentLoginDetails();
			await add_student.AddStudentAsync();
		}

        async void ButtonAdmins_Clicked(System.Object sender, System.EventArgs e)
        {
            var add_admin = new AddAdminLoginDetails();
            await add_admin.AddAdminAsync();
        }

    }
}