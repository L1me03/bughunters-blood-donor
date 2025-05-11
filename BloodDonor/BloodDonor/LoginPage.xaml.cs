
using Microsoft.Maui.Controls;
using System;
using BD.Services;

namespace BD.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var authService = new FirebaseAuthService();

            try
            {
                var token = await authService.Login(emailEntry.Text, passwordEntry.Text);
                if (!string.IsNullOrEmpty(token))
                {
                    await Shell.Current.GoToAsync("//MainPage");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login greška", ex.Message, "OK");
            }
        }
    }
}
