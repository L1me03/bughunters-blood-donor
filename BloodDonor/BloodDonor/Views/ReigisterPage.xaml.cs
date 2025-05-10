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
        var authService = new FirebaseAuthService();

        try
        {
            var token = await authService.Register(emailEntry.Text, passwordEntry.Text);
            await DisplayAlert("Uspje�no", "Registracija je uspje�na", "OK");
            await Shell.Current.GoToAsync("//LoginPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Gre�ka pri registraciji", ex.Message, "OK");
        }
    }

}


