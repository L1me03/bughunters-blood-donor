using AplikacijaDonorApp2.Models;
using Microsoft.Maui.Controls;
using System;
using System.Linq;
using Microsoft.Maui.Controls.Xaml;

namespace AplikacijaDonorApp2.Views
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            LoadDonationData();
        }

        private void LoadDonationData()
        {
            var user = App.CurrentUser;
            if (user == null)
            {
                DisplayAlert("Error", "User not logged in.", "OK");
                return;
            }

            var donations = App.DbContext.Donations
                .Where(d => d.DonorId == user.Id)
                .OrderByDescending(d => d.DonationDate)
                .ToList();

            // Total, last and next
            totalDonationsLabel.Text = $"🩸 Total donation: {donations.Count}";

            if (donations.Any())
            {
                var last = donations.First();
                lastDonationLabel.Text = $"📅 Last donation: {last.DonationDate:dd/MM/yyyy}";
                nextDonationLabel.Text = $"⏰ Next donation date: {last.DonationDate.AddDays(90):dd/MM/yyyy}";
            }
            else
            {
                lastDonationLabel.Text = "📅 Last donation: N/A";
                nextDonationLabel.Text = "⏰ Next donation date: N/A";
            }

            // Zadnje 2 donacije
            if (donations.Count > 0)
            {
                var d1 = donations[0];
                date1Label.Text = $"📅 Date of donation: {d1.DonationDate:dd/MM/yyyy}";
                hospital1Label.Text = $"🏥 Hospital: {d1.Hospital}";
                location1Label.Text = $"📍 Location: {d1.Location}";
                form1Label.Text = $"🩸 Form of blood donation: Whole blood ({user.BloodGroup}, 450ml)";
                status1Label.Text = $"☑️ Donation status: Completed";
            }

            if (donations.Count > 1)
            {
                var d2 = donations[1];
                date2Label.Text = $"📅 Date of donation: {d2.DonationDate:dd/MM/yyyy}";
                hospital2Label.Text = $"🏥 Hospital: {d2.Hospital}";
                location2Label.Text = $"📍 Location: {d2.Location}";
                form2Label.Text = $"🩸 Form of blood donation: Whole blood ({user.BloodGroup}, 450ml)";
                status2Label.Text = $"☑️ Donation status: Completed";
            }
        }

        private void OnShowAllClicked(object sender, EventArgs e)
        {
            allDonationsPanel.Children.Clear();

            var user = App.CurrentUser;
            if (user == null)
                return;

            var donations = App.DbContext.Donations
                .Where(d => d.DonorId == user.Id)
                .OrderByDescending(d => d.DonationDate)
                .ToList();

            int broj = 1;

            foreach (var d in donations)
            {
                var frame = new Frame
                {
                    BackgroundColor = Colors.White,
                    CornerRadius = 15,
                    Padding = 10,
                    WidthRequest = 220,
                    Content = new StackLayout
                    {
                        Spacing = 5,
                        Children =
                        {
                            new Label { Text = $"#{broj}", FontSize = 14, FontAttributes = FontAttributes.Bold },
                            new Label { Text = $"📅 {d.DonationDate:dd/MM/yyyy}", FontSize = 14 },
                            new Label { Text = $"🏥 {d.Hospital}", FontSize = 14 },
                            new Label { Text = $"📍 {d.Location}", FontSize = 14 }
                        }
                    }
                };

                allDonationsPanel.Children.Add(frame);
                broj++;
            }

            allDonationsScrollView.IsVisible = true;
        }
    }
}
