using Microsoft.Maui.Controls;
using BloodDonor.Services;

namespace BloodDonor.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += async (s, e) =>
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        };

        RegisterLabel.GestureRecognizers.Add(tapGesture);
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var authService = new FirebaseAuthService();

        try
        {
            var token = await authService.Login(emailEntry.Text, passwordEntry.Text);

            if (!string.IsNullOrEmpty(token))
            {
                // Login uspešan — idi na glavni meni (npr. MainPage ili Shell route)
                await Shell.Current.GoToAsync("//MainPage");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Login greška", ex.Message, "OK");
        }
    }

}


