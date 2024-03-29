﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CSCResult.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async public void StudentApp_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new StudentApp());
        }

        async public void AdminApp_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AdminApp());
        }
    }
}