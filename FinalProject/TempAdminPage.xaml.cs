using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TempAdminPage : ContentPage
    {
        public TempAdminPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            DisplayAlert("Welcome!", "This is the admin page.", "Understood");
        }

        private void tempAdminclick(object sender, EventArgs e)
        {
            Browser.OpenAsync("https://www.youtube.com/watch?v=EQ3clCcwHFc", BrowserLaunchMode.SystemPreferred);
        }
    }
}