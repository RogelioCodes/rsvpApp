using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TempClientPage : ContentPage
    {
        public TempClientPage()
        {
            InitializeComponent();
        }

        private void RSVPClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RSVPPage());
        }
        //  protected override void OnAppearing()
        //{
        //  DisplayAlert("Welcome!", "This is the Client page.", "Understood");
        //}
    }
}