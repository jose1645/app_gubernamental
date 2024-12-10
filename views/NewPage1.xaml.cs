using sombrero.models;
using sombrero.services;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.Maui.Devices;
using sombrero.GoogleServices;
using System.Net.Security;
using Microsoft.Maui;
using sombrero.Controls;
namespace sombrero.views;


public partial class NewPage1 : ContentPage
{
    private readonly IGoogleAuthService _googleAuthService;
    public user _nuevousuario;

    private Label Encabezadoflyout;
    public string FlyoutHeaderText { get; set; }

    public NewPage1(IGoogleAuthService googleAuthService)
	{
        _googleAuthService = googleAuthService;

        InitializeComponent();
      //  Encabezadoflyout = (Label)FindByName("Encabezadoflyout");

    }

    private async void OnSignInClicked(object sender, EventArgs e)
    {
        var loggedUser = await _googleAuthService.GetCurrentUserAsync();

        if (loggedUser == null)
        {
            loggedUser = await _googleAuthService.AuthenticateAsync();
        }
        _nuevousuario =new user()
        {
            email= loggedUser.Email,    
            name=loggedUser.UserName,

        };

        bool answer = await DisplayAlert("Attention", "Hola" + loggedUser.FullName, "Yes", "No");
        if (loggedUser != null)
        {
            AppShell.Current.FlyoutHeader = new flyoutpageheader_control(_nuevousuario);
            Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
            Shell.SetNavBarIsVisible(this, true);
         //   Encabezadoflyout.Text = loggedUser.FullName;
         lbluser.Text=loggedUser.FullName;













        }
    }
    private async void logoutBtn_Clicked(object sender, EventArgs e)
    {

        await _googleAuthService?.LogoutAsync();

        await Application.Current.MainPage.DisplayAlert("Login Message", "Goodbye", "Ok");
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
        Shell.SetNavBarIsVisible(this, false);
        lbluser.Text = "";
















    }
    protected override bool OnBackButtonPressed() { return true; }


    private async void calendar(object sender, EventArgs e)
    {



    }


}