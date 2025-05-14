using AplikacijaDonorApp2.Models;
using System;

namespace AplikacijaDonorApp2.Views
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) =>
            {
                var window = Application.Current?.Windows.FirstOrDefault();
                if (window is not null)
                {
                    window.Page = new LoginPage();
                }
            };

            SignInLabel.GestureRecognizers.Add(tapGesture);
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // Validacija unosa
            if (string.IsNullOrWhiteSpace(firstNameEntry.Text) ||
                string.IsNullOrWhiteSpace(lastNameEntry.Text) ||
                string.IsNullOrWhiteSpace(emailEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text) ||
                string.IsNullOrWhiteSpace(locationEntry.Text) ||
                string.IsNullOrWhiteSpace(bloodGroupEntry.Text) ||
                string.IsNullOrWhiteSpace(genderEntry.Text) ||
                string.IsNullOrWhiteSpace(phoneEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            // Provera da li korisnik već postoji
            var existingDonor = App.DbContext.Donors.FirstOrDefault(d => d.Email == emailEntry.Text);
            if (existingDonor != null)
            {
                await DisplayAlert("Error", "A donor with this email already exists.", "OK");
                return;
            }

            // Generiši Donor karticu ID
            var random = new Random();
            string donorCardId = "DN-" + random.Next(10000, 99999);

            // Kreiraj novi objekat Donor
            var donor = new Donor
            {
                FirstName = firstNameEntry.Text,
                LastName = lastNameEntry.Text,
                Email = emailEntry.Text,
                Phone = phoneEntry.Text,
                Password = passwordEntry.Text,
                Location = locationEntry.Text,
                BloodGroup = bloodGroupEntry.Text,
                LastDonation = DateTime.Now,
                DonorCardId = donorCardId,
                Gender = genderEntry.Text,
                DateOfBirth = dobPicker.Date,
                // Ispravljeno u skladu s modelom
            };

            // Upis u bazu
            App.DbContext.Donors.Add(donor);
            App.DbContext.SaveChanges();

            App.CurrentUser = donor;

            await DisplayAlert("Success", "You have successfully signed up!", "OK");

            var window = Application.Current?.Windows.FirstOrDefault();
            if (window is not null)
            {
                window.Page = new AppShell();
            }
        }
    }
}
