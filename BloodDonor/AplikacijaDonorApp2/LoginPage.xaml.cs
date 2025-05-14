using AplikacijaDonorApp2.Models;

namespace AplikacijaDonorApp2.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += (s, e) =>
        {
            var window = Application.Current?.Windows.FirstOrDefault();
            if (window is not null)
            {
                window.Page = new SignupPage();
            }
        };

        foreach (var element in MainStack.Children.OfType<Label>())
        {
            if (element.Text.Contains("Sign up"))
                element.GestureRecognizers.Add(tapGesture);
        }
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text?.Trim();
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter both email and password.", "OK");
            return;
        }

        // Provera u bazi
        var user = App.DbContext.Donors
            .FirstOrDefault(d => d.Email == email && d.Password == password);

        if (user != null)
        {
            App.CurrentUser = user; // ✅ DODATO

            await DisplayAlert("Welcome", $"Hello {user.FirstName}!", "OK");

            var window = Application.Current?.Windows.FirstOrDefault();
            if (window is not null)
            {
                window.Page = new AppShell(); // Pokreće Shell i omogućava pristup ProfilePage
            }
        }
        else
        {
            await DisplayAlert("Login Failed", "Incorrect email or password.", "OK");
        }
    }

}
