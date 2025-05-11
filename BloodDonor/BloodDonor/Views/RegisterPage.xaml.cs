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
        // Samo vraća korisnika nazad na login bez autentikacije
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
