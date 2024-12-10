using System.Windows.Input;

namespace sombrero.Botonosersonalizados;

public partial class botonpersonaliozado : Frame
{
    public botonpersonaliozado()
    {
        InitializeComponent();
    }
    public event EventHandler<EventArgs> Tapped;

    private void TabGestureRecognizer_Tapped(object sender, EventArgs e)
    {
       Tapped?.Invoke(sender, e); 
    }



    public static readonly BindableProperty ComanndProperty = BindableProperty.Create(

      propertyName: nameof(command),
      returnType: typeof(ICommand),
      declaringType: typeof(botonpersonaliozado),
      defaultBindingMode: BindingMode.TwoWay

      );
    public ICommand command
    {
        get => (ICommand)GetValue(ComanndProperty);
        set { SetValue(ComanndProperty, value); }
    }


    public static readonly BindableProperty textproperty = BindableProperty.Create(

        propertyName: "Text",
        returnType: typeof(string),
        declaringType: typeof(botonpersonaliozado),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay

        );
    public string Text
    {
        get => (string)GetValue(textproperty);
        set { SetValue(textproperty, value); }
    }

    public static readonly BindableProperty loadingproperty = BindableProperty.Create(

        propertyName: "Text",
        returnType: typeof(string),
        declaringType: typeof(botonpersonaliozado),
        defaultValue: "Enviando reporte...",
        defaultBindingMode: BindingMode.OneWay

        );
    public string loadingtext
    {
        get => (string)GetValue(loadingproperty);
        set { SetValue(loadingproperty, value); }
    }


    public static readonly BindableProperty isinprogress = BindableProperty.Create(

       propertyName: nameof(isinprogress),
       returnType: typeof(bool),
       declaringType: typeof(botonpersonaliozado),
       defaultValue: false,
       propertyChanged: isinprogresspropertychanged
       );
    
    public bool isinsprogress
    {
        get => (bool)GetValue(isinprogress);
        set { SetValue(isinprogress, value); }
    }
    
    private static void isinprogresspropertychanged(BindableObject bindable, object oldValue, object NewValue)
    {
        var controls = (botonpersonaliozado)bindable;
        if (NewValue != null)
        {
            bool isinprogres = (bool)NewValue;
            if (isinprogres)
            {
                controls.lblButtonText.Text = controls.loadingtext;
            }
            else
            {
                controls.lblButtonText.Text = controls.Text;

            }
        }
    }
}