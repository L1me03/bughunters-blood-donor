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

            var userId = App.CurrentUser?.Id ?? 0;
            var user = App.DbContext.Donors.FirstOrDefault(d => d.Id == userId);
            App.CurrentUser = user;

            if (user == null)
            {
                DisplayAlert("Error", "No logged-in user found.", "OK");
                return;
            }

            WelcomeLabel.Text = $"Hi, Dear {user.FirstName}!";
            BloodGroupLabel.Text = user.BloodGroup ?? "-";
            DonorCardLabel.Text = $"CARD ID: {user.DonorCardId}";

            var donations = App.DbContext.Donations
                .Where(d => d.DonorId == user.Id)
                .OrderByDescending(d => d.DonationDate)
                .ToList();

            TotalDonationsLabel.Text = $"TOTAL DONATIONS: {donations.Count}";

            if (donations.Any())
            {
                var last = donations.First().DonationDate;
                NextDonationLabel.Text = $"NEXT DONATION: {last.AddDays(90):dd.MM.yyyy}";
            }
            else
            {
                NextDonationLabel.Text = "NEXT DONATION: N/A";
            }
        }


        private async void OnDonorCardTapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ProfilePage");
        }


    }
}
