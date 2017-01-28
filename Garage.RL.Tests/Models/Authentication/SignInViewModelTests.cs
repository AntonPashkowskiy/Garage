using Garage.RL.Models.Authentication;
using NUnit.Framework;
using System;

namespace Garage.RL.Tests.Models.Authentication
{
    [TestFixture]
    public class SignInViewModelTests
    {
        #region MapToModel

        [Test]
        public void MapToModel_ViewModelIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SignInViewModel.MapToModel(null));
        }

        [Test]
        [TestCase("admin", "admin")]
        [TestCase(null, "admin")]
        [TestCase("admin", null)]
        [TestCase(null, null)]
        public void MapToModel_ViewModelIsNotNull_ModelAndViewModelPropertiesAreEquals(string login, string password)
        {
            var viewModel = new SignInViewModel
            {
                Login = login,
                Password = password
            };
            var model = SignInViewModel.MapToModel(viewModel);

            Assert.That(() => {
                return viewModel.Login == model.Login &&
                       viewModel.Password == model.Password;
            });
        }

        #endregion
    }
}
