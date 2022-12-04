using CSCResult.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CSCResult.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}