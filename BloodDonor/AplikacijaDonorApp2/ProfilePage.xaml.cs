using System.Xml;
using AplikacijaDonorApp2.Models;
namespace AplikacijaDonorApp2.Views;

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
        if(user is null)
        {
            DisplayAlert("Error", "User not found.", "OK");
            return;
        }
        NameLabel.Text = $"Name: {user.FirstName} {user.LastName}";
        EmailLabel.Text = $"E-mail: {user.Email}";
        BloodTypeButton.Text = $"Blood type: {user.BloodGroup}";
        

        DateTime nextDonation = user.LastDonation.AddDays(90);
        NextDonationButton.Text = $"Next donation: {nextDonation:dd.MM.yyyy}";
    }
}
