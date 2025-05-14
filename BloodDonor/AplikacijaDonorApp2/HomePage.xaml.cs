using AplikacijaDonorApp2.Models;

namespace AplikacijaDonorApp2.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var user = App.CurrentUser;
            if (user is null)
            {
                DisplayAlert("Error", "No logged-in user found.", "OK");
                return;
            }

            // Prikaz podataka
            WelcomeLabel.Text = $"Hi, Dear {user.FirstName}!";
            BloodGroupLabel.Text = user.BloodGroup ?? "-";
            TotalDonationsLabel.Text = $"TOTAL DONATIONS: {user.TotalDonations}";
            DonorCardLabel.Text = $"CARD ID: {user.DonorCardId}";
            NextDonationLabel.Text = $"NEXT DONATION: {user.LastDonation.AddDays(90):dd.MM.yyyy}";
        }

        private async void OnDonorCardTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ProfilePage");
        }
    }
}
