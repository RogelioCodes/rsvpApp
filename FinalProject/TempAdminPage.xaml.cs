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
       // protected override void OnAppearing()
       // {
       //     DisplayAlert("Welcome!", "This is the admin page.", "Understood");
       // }

        private void MakeEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MakeEventPage());
        }

        private void CancelEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CancelEventPage());
        }

        private void RescheduleEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RescheduleEventPage());
        }
    }
}