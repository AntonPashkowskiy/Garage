using Garage.BLL.Services.Interfaces.Authentication;
using Garage.RL.Managers;
using XLabs.Ioc;

namespace Garage.RL.Configuration
{
    public class AppConfigurator : IAppConfigurator
    {
        #region Fields

        private readonly IResolver _dependencyResolver;

        #endregion

        #region Ctor

        public AppConfigurator(IResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        #endregion

        #region Public Methods

        public void SetUp()
        {
            AuthenticationManager.AuthenticationService = _dependencyResolver.Resolve<IAuthenticationService>();
        } 

        #endregion
    }
}
