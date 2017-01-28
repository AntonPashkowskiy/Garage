using Garage.BLL.Services.Models.Authentication;
using Garage.Core.Utils;

namespace Garage.RL.Models.Authentication
{
    public class SignInViewModel
    {
        #region Properties

        public string Login { get; set; }
        public string Password { get; set; }

        #endregion

        #region Mapping

        public static SignInModel MapToModel(SignInViewModel viewModel)
        {
            Guard.ExpectArgumentIsNotNull(() => viewModel);

            return new SignInModel
            {
                Login = viewModel.Login,
                Password = viewModel.Password
            };
        }

        #endregion
    }
}
