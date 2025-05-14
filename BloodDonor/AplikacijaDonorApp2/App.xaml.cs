using AplikacijaDonorApp2.Data;
using AplikacijaDonorApp2.Models;


namespace AplikacijaDonorApp2
{
    public partial class App : Application
    {
        public static AppDbContext DbContext { get; private set; } = null!;
        public static Donor? CurrentUser { get; set; }

        public App()
        {
            InitializeComponent();

            DbContext = new AppDbContext(); // inicijalizacija baze
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new Views.SplashPage()));
        }
    }
}
