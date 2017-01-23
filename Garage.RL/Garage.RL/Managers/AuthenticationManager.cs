using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Garage.RL.Managers
{
    public static class AuthenticationManager
    {
        private static bool _isUserAuthenticated;

        #region Properties

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
