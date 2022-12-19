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
	public partial class StudentRegistration : ContentPage
	{
		public StudentRegistration ()
		{
			InitializeComponent ();
		}
        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (EntryPassword.IsPassword)
            {
                EntryPassword.IsPassword = false;
            }
            else
            {
                EntryPassword.IsPassword = true;
            }
        }
    }
}