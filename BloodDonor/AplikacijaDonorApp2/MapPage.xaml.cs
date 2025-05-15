using System.Net.NetworkInformation;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AplikacijaDonorApp2.Views;

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();

        // Centriraj mapu na Sarajevo
        donorMap.MoveToRegion(MapSpan.FromCenterAndRadius(
            new Location(43.8563, 18.4131), Distance.FromKilometers(5)));

        // Dodaj jedan pin za test
        var testPin = new Pin
        {
            Label = "Donor: Marko",
            Address = "Kranjèeviæeva, Sarajevo",
            Location = new Location(43.8563, 18.4131),
            Type = PinType.Place
        };

        donorMap.Pins.Add(testPin);
    }
}
