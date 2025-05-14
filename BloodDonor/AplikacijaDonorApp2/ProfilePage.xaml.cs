using AplikacijaDonorApp2.Models;

namespace AplikacijaDonorApp2.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            var user = App.CurrentUser;
            if (user is null)
            {
                DisplayAlert("Error", "User not found.", "OK");
                return;
            }

            NameLabel.Text = $"Name: {user.FirstName} {user.LastName}";
            EmailLabel.Text = $"E-mail: {user.Email}";
            GenderLabel.Text = $"Gender: {user.Gender ?? "-"}";
            PhoneLabel.Text = $"Phone: {user.Phone ?? "-"}";
            DobLabel.Text = $"Date of birth: {(user.DateOfBirth.HasValue ? user.DateOfBirth.Value.ToString("dd.MM.yyyy") : "-")}";

            BloodTypeButton.Text = $"Blood type: {user.BloodGroup ?? "-"}";

            DateTime nextDonation = user.LastDonation.AddDays(90);
            NextDonationButton.Text = $"Next donation: {nextDonation:dd.MM.yyyy}";

            // Ukupan broj donacija (ako imaš to polje)
            TotalDonationButton.Text = $"Total donation: {user.TotalDonations}";
        }
    }
}
