using Garage.BLL.Services.Interfaces.Authentication;
using Garage.Core.Utils;
using Garage.RL.Managers;
using Garage.RL.Models.Authentication;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.RL.Tests.Managers
{
    [TestFixture]
    public class AuthenticationManagerTests
    {
        #region Fields

        private IAuthenticationService _authenticationService;

        #endregion

        #region Init

        [SetUp]
        public void Init()
        {
            _authenticationService = Substitute.For<IAuthenticationService>();
        }

        #endregion

        #region SignInAsync

        [Test]
        public async Task SignInAsync_SignInViewModelIsNull_ThrowsArgumentNullException()
        {
            var exception = await AssertAsyncUtil.ThrowsAsync<ArgumentNullException>(() => AuthenticationManager.SignInAsync(null));

            Assert.That(() => exception != null && exception.GetType() == typeof(ArgumentNullException));
        }

        [Test]
        public async Task SignInAsync_SignInViewModelIsNotNull_ExecutesServiceMethod()
        {
            SetUpAuthenticationManager();
            await AuthenticationManager.SignInAsync(GetEmptySignInViewModel());

            Assert.IsTrue(_authenticationService.ReceivedCalls().Any());
        }

        [Test]
        public async Task SignInAsync_SignInViewModelIsNotNull_IsUserAuthenticatedIsTrue()
        {
            SetUpAuthenticationManager();
            await AuthenticationManager.SignInAsync(GetEmptySignInViewModel());

            Assert.IsTrue(AuthenticationManager.IsUserAuthenticated);
        }

        #endregion

        #region SignUpAsync

        [Test]
        public async Task SignUpAsync_SignUpViewModelIsNull_ThrowsArgumentNullException()
        {
            var exception = await AssertAsyncUtil.ThrowsAsync<ArgumentNullException>(() => AuthenticationManager.SignUpAsync(null));

            Assert.That(() => exception != null && exception.GetType() == typeof(ArgumentNullException));
        }

        [Test]
        public async Task SignupAsync_SignUpViewModelIsNotNull_ExecutesServiceMethod()
        {
            SetUpAuthenticationManager();
            await AuthenticationManager.SignUpAsync(GetEmptySignUpViewModel());

            Assert.IsTrue(_authenticationService.ReceivedCalls().Any());
        }

        #endregion

        #region Private Methods

        private void SetUpAuthenticationManager()
        {
            _authenticationService.ClearReceivedCalls();
            AuthenticationManager.AuthenticationService = _authenticationService;
        }

        private SignInViewModel GetEmptySignInViewModel()
        {
            return new SignInViewModel();
        }

        private SignUpViewModel GetEmptySignUpViewModel()
        {
            return new SignUpViewModel();
        }

        #endregion
    }
}
