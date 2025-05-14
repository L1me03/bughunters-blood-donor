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
                string.IsNullOrWhiteSpace(cityEntry.Text) ||
                string.IsNullOrWhiteSpace(countryEntry.Text) ||
                string.IsNullOrWhiteSpace(bloodGroupEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            // Generiši Donor kartica ID
            var random = new Random();
            string donorCardId = "DN-" + random.Next(10000, 99999);

            // Kreiraj novi objekat Donor
            var donor = new Donor
            {
                FirstName = firstNameEntry.Text,
                LastName = lastNameEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                Country = countryEntry.Text,
                BloodGroup = bloodGroupEntry.Text,
                LastDonation = DateTime.Now,
                DonorCardId = donorCardId
            };

            // Upis u bazu
            App.DbContext.Donors.Add(donor);
            App.DbContext.SaveChanges();

            // ? Postavi aktivnog korisnika
            App.CurrentUser = donor;

            await DisplayAlert("Success", "You have successfully signed up!", "OK");

            // Pokreni AppShell (meni + HomePage)
            var window = Application.Current?.Windows.FirstOrDefault();
            if (window is not null)
            {
                window.Page = new AppShell();
            }
        }
    }
}
