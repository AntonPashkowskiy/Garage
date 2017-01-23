using Garage.RL.Configuration;
using Garage.RL.Pages;
using Xamarin.Forms;

namespace Garage.RL
{
    public class App : Application
    {
        #region Ctor

        public App(IAppConfigurator configurator)
        {
            configurator.SetUp();
            MainPage = new NavigationPage(new MainProfilePage());
        }

        #endregion
    }
}
