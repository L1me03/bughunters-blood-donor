namespace AplikacijaDonorApp2.Views;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
        StartTimer();
    }

    private async void StartTimer()
    {
        await Task.Delay(5000);

        var window = Application.Current?.Windows.FirstOrDefault();
        if (window is not null)
        {
            window.Page = new NavigationPage(new LoginPage());
        }
    }
}
