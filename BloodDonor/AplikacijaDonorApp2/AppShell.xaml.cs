using AplikacijaDonorApp2.Models;
using AplikacijaDonorApp2.Views;

namespace AplikacijaDonorApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            LoadUserName();
        }

        private void LoadUserName()
        {
            var user = App.CurrentUser;
            if (user != null)
            {
                UserLabel.Text = $"{user.FirstName} {user.LastName}";
            }
            else
            {
                UserLabel.Text = "Welcome!";
            }
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            var window = Application.Current?.Windows.FirstOrDefault();
            if (window is not null)
            {
                window.Page = new LogoutPage(); // poziva LogoutPage umesto Shell navigacije
            }
        }
    }
}
