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

    private void OnLoginClicked(object sender, EventArgs e)
    {
        var window = Application.Current?.Windows.FirstOrDefault();
        if (window is not null)
        {
            window.Page = new AppShell();
        }
    }
}
