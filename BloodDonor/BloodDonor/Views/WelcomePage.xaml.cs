using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace BloodDonor.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            StartTimer();
        }

        private async void StartTimer()
        {
            await Task.Delay(5000); // 5 sekundi
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
