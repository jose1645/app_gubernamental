using sombrero.models;
using sombrero.views;

namespace sombrero.Controls;

public partial class flyoutpageheader_control : StackLayout
{
	public flyoutpageheader_control(user usuario)
	{
        InitializeComponent();


        lblUserName.Text = usuario.email.ToString();
        lblUserEmail.Text = usuario.name.ToString() ;
        //lblUserRole.Text = "asdas";

    }
}