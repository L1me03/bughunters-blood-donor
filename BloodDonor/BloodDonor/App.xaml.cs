using BloodDonor.Views;

namespace BloodDonor;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Shell kao glavni layout koji koristi rute za navigaciju
        MainPage = new AppShell();
    }
}
