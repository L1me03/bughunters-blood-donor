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
        // Skip authentication logic and go directly to MainMenuPage
        await Shell.Current.GoToAsync(nameof(MainMenuPage));
    }
    private async void OnRegisterLabelTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));
    }
}