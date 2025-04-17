using Microsoft.Maui.Controls;

namespace BloodDonor.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();

        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += async (s, e) =>
        {
            await Shell.Current.GoToAsync("//LoginPage");
        };

        LoginLabel.GestureRecognizers.Add(tapGesture);
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Register", "Registration logic goes here", "OK");
    }
}
