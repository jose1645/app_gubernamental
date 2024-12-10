using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using sombrero.models;
using sombrero.views;
using sombrero.services;

namespace sombrero.viewmodels
{
    public class IntroScreenViewModel : BaseViewModel
    {

        private int _position;
        public int Position
        {
            get => _position;
            set => SetProperty(ref _position, value, onChanged: (() =>
            {
                if(value==IntroScreens.Count - 1)
                {
                    ButtonText = "Inicio";
                }
                else
                {
                    ButtonText = "Siguiente";
                }
            }));

        }
        #region Properties
        private string _buttontext="Siguiente";
        public string ButtonText
        {
            get => _buttontext;
            set => SetProperty(ref _buttontext, value);
        }

        public ObservableCollection<IntroScreenModel> IntroScreens { get; set; } = new ObservableCollection<IntroScreenModel>();
        #endregion

        public IntroScreenViewModel()
        {


            IntroScreens.Add(new IntroScreenModel
            {
                IntroScreenTitle="Servicios",
                IntroDescription= "Aqui puedes hacer:\n °Reportar baches \n °Localizar baches\n °Agendar citas",
                IntroImage="services"

            });

            IntroScreens.Add(new IntroScreenModel
            {
                IntroScreenTitle = "asdagfdfg",
                IntroDescription = "asdjajnf",
                IntroImage = "bache"

            });

            IntroScreens.Add(new IntroScreenModel
            {
                IntroScreenTitle = "fulano tadsfsdfslafgadgdfsg",
                IntroDescription = "assdfsdfdjajnf",
                IntroImage = "dotnet_bot"

            });

        }
        public ICommand Nextcommand => new Command(async () =>
        {
            if (Position >= IntroScreens.Count-1)
            {
     
                 Shell.Current.GoToAsync("//NewPage1");
            }
            else
            {
                Position += 1;

            }
        });
    }
  
}
