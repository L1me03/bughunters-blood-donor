using AplikacijaDonorApp2.Data;
using AplikacijaDonorApp2.Models;
using System;

namespace AplikacijaDonorApp2.Views
{
    public partial class DonatePage : ContentPage
    {
        public DonatePage()
        {
            InitializeComponent();
        }

        private async void OnConfirmClicked(object sender, EventArgs e)
        {
            var user = App.CurrentUser;
            if (user == null)
            {
                await DisplayAlert("Error", "No user is logged in.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(locationEntry.Text) ||
                string.IsNullOrWhiteSpace(hospitalEntry.Text))
            {
                await DisplayAlert("Validation", "Please enter location and hospital.", "OK");
                return;
            }

            var donation = new Donation
            {
                DonorId = user.Id,
                DonationDate = donationDatePicker.Date,
                Location = locationEntry.Text,
                Hospital = hospitalEntry.Text,
                Notes = notesEditor.Text
            };

            try
            {
                App.DbContext.Donations.Add(donation);
                App.DbContext.SaveChanges();

                await DisplayAlert("Success", "Donation successfully recorded!", "OK");

                locationEntry.Text = "";
                hospitalEntry.Text = "";
                notesEditor.Text = "";
                donationDatePicker.Date = DateTime.Today;
            }
            catch (Exception ex)
            {
                await DisplayAlert("DB Error", ex.InnerException?.Message ?? ex.Message, "OK");
            }
        }

    }
}
