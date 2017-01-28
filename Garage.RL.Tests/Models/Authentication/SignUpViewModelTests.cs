using Garage.RL.Models.Authentication;
using NUnit.Framework;
using System;

namespace Garage.RL.Tests.Models.Authentication
{
    [TestFixture]
    public class SignUpViewModelTests
    {
        #region MapToModel

        [Test]
        public void MapToModel_ViewModelIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SignUpViewModel.MapToModel(null));
        }

        [Test]
        [TestCase("Admin", "Admin", "admin@admin.ad", "1234567", 5)]
        [TestCase(null, null, null, null, 0)]
        public void MapToModel_ViewModelIsNotNull_ViewModelAndModelPropertiesAreEquals(
            string name,
            string login,
            string email,
            string password,
            int drivingExperience)
        {
            var viewModel = new SignUpViewModel
            {
                Name = name,
                Login = login, 
                Email = email,
                Password = password,
                DrivingExpirience = drivingExperience
            };
            var model = SignUpViewModel.MapToModel(viewModel);

            Assert.That(() =>
            {
                return model.Name == viewModel.Name &&
                       model.Login == viewModel.Login &&
                       model.Email == viewModel.Email &&
                       model.Password == viewModel.Password &&
                       model.DrivingExpirience == viewModel.DrivingExpirience;
            });
        }

        #endregion
    }
}
