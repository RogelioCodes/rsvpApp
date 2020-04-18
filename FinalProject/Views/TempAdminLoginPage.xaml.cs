using FinalProject.Model;
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
    public partial class TempAdminLoginPage : ContentPage
    {
        public TempAdminLoginPage()
        {
            InitializeComponent();
        }
        void AdminClick(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TempAdminPage());
        }

        private void Btn_Signin_Clicked(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if(user.CheckPassword())
            {
                DisplayAlert("Login", "Login Successful", "ok");
               // App.UserDatabase.SaveUser(user); keep this commented out, it worked one day, then the next it throws an exception error that breaks the app
                Navigation.PushAsync(new TempAdminPage());
            }
            else
            {
                DisplayAlert("Login", "Login Failed", "ok");
            }
        }
    }
}