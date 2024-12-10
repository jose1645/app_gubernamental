using sombrero.viewmodels;

namespace sombrero.views;

public partial class IntroScreenView : ContentPage
{
	public IntroScreenView()
	{
        InitializeComponent();
        this.BindingContext=new IntroScreenViewModel();


    }


  


}