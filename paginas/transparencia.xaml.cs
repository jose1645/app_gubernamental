namespace sombrero.paginas;

public partial class transparencia : ContentPage
{
	public transparencia()
	{
		InitializeComponent();
	}

    private async void OnInformeAnualClicked(object sender, EventArgs e)
    {
        // Reemplaza con la URL real del informe
        string informeAnualUrl = "https://www.example.com/informe_anual_2024";
        await Launcher.OpenAsync(new Uri(informeAnualUrl));
    }

    private async void OnPresupuestoClicked(object sender, EventArgs e)
    {
        // Reemplaza con la URL real del presupuesto
        string presupuestoUrl = "https://www.example.com/presupuesto_2024";
        await Launcher.OpenAsync(new Uri(presupuestoUrl));
    }

    private async void OnExplorarDatosClicked(object sender, EventArgs e)
    {
        // Reemplaza con la URL real de los datos abiertos
        string datosAbiertosUrl = "https://www.example.com/datos_abiertos";
        await Launcher.OpenAsync(new Uri(datosAbiertosUrl));
    }

    private async void OnAuditoriaClicked(object sender, EventArgs e)
    {
        // Reemplaza con la URL real de los resultados de auditoría
        string auditoriaUrl = "https://www.example.com/auditoria_2024";
        await Launcher.OpenAsync(new Uri(auditoriaUrl));
    }

    private async void OnContactarClicked(object sender, EventArgs e)
    {
        // Reemplaza con la URL real para contactar
        string contactoUrl = "https://www.example.com/contacto";
        await Launcher.OpenAsync(new Uri(contactoUrl));
    }
}