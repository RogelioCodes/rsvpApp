﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavPage : ContentPage
    {
        public NavPage()
        {
            InitializeComponent();
        }
        void AdminClick(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TempAdminPage());
        }
        void ClientClick(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TempClientPage());
        }
    }
}