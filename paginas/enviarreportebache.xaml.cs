using System.Text;
using System.Text.Json;

namespace sombrero.paginas;

public partial class enviarreportebache : ContentPage
{
    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;
    public string direccion = "";
    public string longitud = "";
    public string latitud = "";
    public string error = ""; 


    public enviarreportebache()
    {
        InitializeComponent();

    }


    public async void OnButtonPressed(object sender, EventArgs args)
    {
      

    }


    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }

    private async void btn1_Tapped(object sender, EventArgs e)
    {
        btn1.isinsprogress = true;
        btn1.IsEnabled = false;  
        try
        {
            _isCheckingLocation = true;
            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
            {
                latitud = Convert.ToString(location.Latitude);
                longitud = Convert.ToString(location.Longitude);
                direccion = latitud + "," + longitud;
            }
        }
        catch (Exception ex)
        {
            error = ex.Message;
        }
        finally
        {
            _isCheckingLocation = false;
        }
        try
        {
            string url = "https://s315om9r2b.execute-api.us-east-1.amazonaws.com/crearreportebache";
            HttpClient client = new HttpClient();
            var requestData = new { latitud = latitud, longitud = longitud, fecha = DateTime.Now.ToString("yyyy,MM,dd HH:mm:ss"), so = DeviceInfo.Platform, modelo = DeviceInfo.Model, manofactura = DeviceInfo.Manufacturer, nombre = DeviceInfo.Name, tipodispositivo = DeviceInfo.DeviceType, version = DeviceInfo.Version, existe = 1 }; // data en diccionario
            string json = JsonSerializer.Serialize(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            string responseContent = await response.Content.ReadAsStringAsync();
            error = responseContent;
           string respuesta="el folio de tu reporte es: " + error;
            await Task.Delay(1000); //controlar el acceso a boton
            await DisplayAlert("Exito",respuesta, "OK");



        }

        catch (Exception ex)
        {


        }



        btn1.IsEnabled = true; 
        btn1.isinsprogress = false;

    }

  
}




