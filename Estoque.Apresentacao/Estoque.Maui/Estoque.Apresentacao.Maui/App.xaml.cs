using Estoque.Apresentacao.Maui.Components;

namespace Estoque.Apresentacao.Maui
{
    public partial class App : IApplication
    {
        public App()
        {
            InitializeComponent();

            App.Current.UserAppTheme = AppTheme.Light;

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}