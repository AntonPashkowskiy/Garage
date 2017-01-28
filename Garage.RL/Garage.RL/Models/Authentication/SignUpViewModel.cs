using Garage.BLL.Services.Models.Authentication;
using Garage.Core.Utils;

namespace Garage.RL.Models.Authentication
{
    public class SignUpViewModel
    {
        #region Properties

        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int DrivingExpirience { get; set; }

        #endregion

        #region Mapping

        public static SignUpModel MapToModel(SignUpViewModel viewModel)
        {
            Guard.ExpectArgumentIsNotNull(() => viewModel);

            return new SignUpModel
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Login = viewModel.Login,
                Password = viewModel.Password,
                DrivingExpirience = viewModel.DrivingExpirience
            };
        }

        #endregion
    }
}
