namespace AplikacijaDonorApp2.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnDonorCardTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ProfilePage");
    }
}
