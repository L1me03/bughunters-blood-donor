using AplikacijaDonorApp2.Views;

namespace AplikacijaDonorApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
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

