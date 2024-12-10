using Microsoft.Extensions.DependencyInjection;
using sombrero.objetos;
using sombrero.views;

namespace sombrero
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF1cWWhAYVVpR2Nbe05xdl9CaFZRRGY/P1ZhSXxXdk1gWX5cdHxVRmZbWUw=");

            InitializeComponent();

            Services = serviceProvider;

            //MainPage = new IntroScreenView();
            MainPage = new AppShell();

            //bool answer = await DisplayAlert("Attention", "Hola" + loggedUser.FullName, "Yes", "No");

        }


    }
    }
