using Garage.BLL.Services.Interfaces.Authentication;
using Garage.Core.Utils;
using Garage.RL.Models.Authentication;
using System.Threading.Tasks;

namespace Garage.RL.Managers
{
    public static class AuthenticationManager
    {
        #region Fields

        private static bool? _isUserAuthenticated;

        #endregion

        #region Properties

        public static IAuthenticationService AuthenticationService { get; set; }

        public static bool IsUserAuthenticated
        {
            get
            {
                if (!_isUserAuthenticated.HasValue)
                {
                    _isUserAuthenticated = AuthenticationService.IsUserAuthenticated();
                }
                return _isUserAuthenticated.Value;
            }

            private set
            {
                _isUserAuthenticated = value;
            }
        }

        #endregion

        #region Public Methods

        public async static Task SignUpAsync(SignUpViewModel viewModel)
        {
            Guard.ExpectArgumentIsNotNull(() => viewModel);

            await AuthenticationService.SignUpAsync(SignUpViewModel.MapToModel(viewModel));
        }

        public async static Task SignInAsync(SignInViewModel viewModel)
        {
            Guard.ExpectArgumentIsNotNull(() => viewModel);

            await AuthenticationService.SignInAsync(SignInViewModel.MapToModel(viewModel));
            IsUserAuthenticated = true;
        }

        public static void SignOutAsync()
        {

        }

        #endregion
    }
}
