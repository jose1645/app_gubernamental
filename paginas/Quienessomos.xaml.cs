namespace sombrero.paginas;

public partial class Quienessomos : ContentPage
{
	public Quienessomos()
	{
		InitializeComponent();
	}


    private async void OnFacebookClicked(object sender, EventArgs e)
    {
        string facebookUrl = "https://www.facebook.com/your_facebook_page";
        await Launcher.OpenAsync(new Uri(facebookUrl));
    }

    private async void OnTwitterClicked(object sender, EventArgs e)
    {
        string twitterUrl = "https://twitter.com/your_twitter_handle";
        await Launcher.OpenAsync(new Uri(twitterUrl));
    }

    private async void OnInstagramClicked(object sender, EventArgs e)
    {
        string instagramUrl = "https://www.instagram.com/your_instagram_handle";
        await Launcher.OpenAsync(new Uri(instagramUrl));
    }

}