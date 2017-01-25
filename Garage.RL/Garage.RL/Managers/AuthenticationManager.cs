using Garage.BLL.Services.Interfaces.Authentication;
using Xamarin.Auth;

namespace Garage.RL.Managers
{
    public static class AuthenticationManager
    {
        private static bool _isUserAuthenticated;

        #region Properties

        public static IAuthenticationService AuthenticationService { get; set; }

        public static bool IsUserAuthenticated
        {
            get
            {
                return _isUserAuthenticated;
            }

            private set
            {
                _isUserAuthenticated = value;
            }
        }

        #endregion

        #region Public Methods

        public static void SignUp(Account account)
        {

        }

        public static void SignIn(Account account)
        {
            IsUserAuthenticated = true;
        }

        public static void SignOut()
        {

        }

        #endregion
    }
}
