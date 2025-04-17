using BloodDonor.Views;

namespace BloodDonor;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes for navigation
        Routing.RegisterRoute("WelcomePage", typeof(WelcomePage));
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
    }
}
