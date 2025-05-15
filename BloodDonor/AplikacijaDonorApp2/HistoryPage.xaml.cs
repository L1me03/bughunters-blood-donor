using AplikacijaDonorApp2.Data;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace AplikacijaDonorApp2.Views
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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

            // ✅ Total
            totalDonationsLabel.Text = $"🩸 Total donation: {donations.Count}";

            // ✅ Last & next
            if (donations.Any())
            {
                var last = donations.First().DonationDate;
                lastDonationLabel.Text = $"📅 Last donation: {last:dd.MM.yyyy}";
                nextDonationLabel.Text = $"⏰ Next donation date: {last.AddDays(90):dd.MM.yyyy}";
            }
            else
            {
                lastDonationLabel.Text = "📅 Last donation: N/A";
                nextDonationLabel.Text = "⏰ Next donation date: N/A";
            }

            // ✅ Poslednje 2
            if (donations.Count > 0)
            {
                var d1 = donations[0];
                date1Label.Text = $"📅 Date of donation: {d1.DonationDate:dd.MM.yyyy}";
                hospital1Label.Text = $"🏥 Hospital: {d1.Hospital}";
                location1Label.Text = $"📍 Location: {d1.Location}";
                form1Label.Text = $"🩸 Form of blood donation: Whole blood ({user.BloodGroup}, 450ml)";
                status1Label.Text = $"☑️ Donation status: Completed";
            }
            else
            {
                date1Label.Text = hospital1Label.Text = location1Label.Text =
                form1Label.Text = status1Label.Text = "";
            }

            if (donations.Count > 1)
            {
                var d2 = donations[1];
                date2Label.Text = $"📅 Date of donation: {d2.DonationDate:dd.MM.yyyy}";
                hospital2Label.Text = $"🏥 Hospital: {d2.Hospital}";
                location2Label.Text = $"📍 Location: {d2.Location}";
                form2Label.Text = $"🩸 Form of blood donation: Whole blood ({user.BloodGroup}, 450ml)";
                status2Label.Text = $"☑️ Donation status: Completed";
            }
            else
            {
                date2Label.Text = hospital2Label.Text = location2Label.Text =
                form2Label.Text = status2Label.Text = "";
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
                            new Label { Text = $"📅 {d.DonationDate:dd.MM.yyyy}", FontSize = 14 },
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
