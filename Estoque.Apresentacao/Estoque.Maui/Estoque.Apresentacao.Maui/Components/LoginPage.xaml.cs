namespace Estoque.Apresentacao.Maui.Components;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void Entrar(object sender, EventArgs e)
    {
		App.Current.MainPage = new SideBarMenu();
    }
}