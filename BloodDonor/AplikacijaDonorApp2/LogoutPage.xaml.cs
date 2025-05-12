namespace AplikacijaDonorApp2.Views;

public partial class LogoutPage : ContentPage
{
    public LogoutPage()
    {
        InitializeComponent();
        StartLogoutTimer();
    }

    private async void StartLogoutTimer()
    {
        await Task.Delay(3000); 

        var window = Application.Current?.Windows.FirstOrDefault();
        if (window is not null)
        {
            window.Page = new LoginPage();
        }
    }
}
