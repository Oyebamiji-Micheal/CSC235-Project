using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSCResult.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentPage : ContentPage
	{
		public StudentPage ()
		{
			InitializeComponent ();
		}
        private void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            // Perform logout logic here
        }

        private void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            // Perform register for course logic here
        }

        private void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            // Perform update profile logic here
        }
    }
}