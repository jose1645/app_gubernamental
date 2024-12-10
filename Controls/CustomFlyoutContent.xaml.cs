using sombrero.ImportGoogleCalendar;
using sombrero.objetos;
using sombrero.paginas;
using sombrero.services;

namespace sombrero.Controls;

public partial class CustomFlyoutContent : ContentView
{

    public CustomFlyoutContent()
        
	{
		InitializeComponent();
	}
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        
        Navigation.PushAsync(new enviarreportebache());
        Shell.Current.FlyoutIsPresented = false;

    }

    private async void irmapabache(object sender, EventArgs e)
    {

        // Obtén la instancia de SecretsConfig desde el contenedor de dependencias
      //  var secrets = App.Services.GetService<SecretsConfig>();





        Navigation.PushAsync(new bachemapa());
        Shell.Current.FlyoutIsPresented = false;

    }

    private async void irmas(object sender, EventArgs e)
    {

        Navigation.PushAsync(new mas());
        Shell.Current.FlyoutIsPresented = false;

    }

    private async void irquienessomos(object sender, EventArgs e)
    {

        Navigation.PushAsync(new Quienessomos());
        Shell.Current.FlyoutIsPresented = false;

    }

    private async void irtransparencia(object sender, EventArgs e)
    {
        Navigation.PushAsync(new transparencia());
        Shell.Current.FlyoutIsPresented = false;

    }



    private async void irlogin(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new login());
        //Shell.Current.FlyoutIsPresented = false;

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e) { 
        Navigation.PushAsync(new agenda_consultas());
        Shell.Current.FlyoutIsPresented = false;
    }


    
}