using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Text;
using Newtonsoft.Json;
using sombrero.services;
using sombrero.objetos;
using Map = Microsoft.Maui.Controls.Maps.Map;
using sombrero.views;
namespace sombrero.paginas;


public partial class bachemapa : ContentPage
{
    public List<Pin> Pins { get; set; } = new List<Pin>();
    public List<bache>listabaches { get; set; }=new List<bache>();
    // private readonly obtenerbaches _obtenerbaches;
    //private readonly SecretsConfig _secrets;

    public bachemapa()
    {
        InitializeComponent();
      //  _secrets = secrets;

    }


    protected async override void OnAppearing()
    {


        //base.OnAppearing();

        obtenerbaches obtenerbacheservice = new obtenerbacheservice();
        listabaches= await obtenerbacheservice.obtener();
        var gelocationRequest = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(20));
        var location = await Geolocation.GetLocationAsync(gelocationRequest);
        map.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(5)));

        foreach (bache item in listabaches)
        {
            if (item.latitud != "" && item.longitud != "")
            {
                Pins.Add(new Pin
                {
                    Label = Convert.ToString("Reportado por " + item.nombre),
                    Address = Convert.ToString(item.id),
                    Location = new Location(Convert.ToDouble(item.latitud), Convert.ToDouble(item.longitud))
                });
            }
        }

        map.ItemsSource = Pins;

        





    }


    async void OnMarkerClicked(object sender, PinClickedEventArgs args)
    {
        args.HideInfoWindow = true;
        Pin p = (Pin)sender;
        bool answer = await DisplayAlert("Ya no existe el bache?", p.Label + " \n en caso afirmativo", "Yes", "No");
        //p.Address trae el id
        if (answer == true)
        {
            //mandar a escribir a api
            // URL del recurso
            string url = "tu endpoint";

            // Datos a enviar
            dynamic datos = new
            {
                id = p.Address,
                existe = "0"
            };

            // Convertir datos a JSON
            string json = JsonConvert.SerializeObject(datos);

            // Crear solicitud HTTP PUT
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            // Enviar solicitud
            HttpResponseMessage response = client.SendAsync(request).Result;

            Navigation.PushAsync(new transparencia());
            Shell.Current.FlyoutIsPresented = false;
        }

    }














}