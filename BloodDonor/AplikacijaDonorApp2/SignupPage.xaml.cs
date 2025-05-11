namespace AplikacijaDonorApp2.Views;

public partial class SignupPage : ContentPage
{
    public SignupPage()
    {
        InitializeComponent();

        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += (s, e) =>
        {
            var window = Application.Current?.Windows.FirstOrDefault();
            if (window is not null)
            {
                window.Page = new LoginPage();
            }
        };

        SignInLabel.GestureRecognizers.Add(tapGesture);
    }

    private void OnSignUpClicked(object sender, EventArgs e)
    {
        var window = Application.Current?.Windows.FirstOrDefault();
        if (window is not null)
        {
            window.Page = new AppShell();
        }
    }
}
