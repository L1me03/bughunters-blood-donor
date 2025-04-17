using Microsoft.Maui.Controls;

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
        await DisplayAlert("Login", "Login logic goes here", "OK");
    }
}