using Garage.RL.Managers;
using Garage.RL.Models.Authentication;
using Garage.RL.Utilities.Behaviours;
using System;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Garage.RL.Pages.Authentication
{
    public partial class SignInPage : ContentPage
    {
        #region Ctor

        public SignInPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Events Handlers

        public async Task SignInButtonClicked(object sender, EventArgs eventArgs)
        {
            ValidateSignInForm();

            if (IsSignInFormValid())
            {
                await AuthenticationManager.SignInAsync(GetViewModel());
            }
        }

        #endregion

        #region Private Methods

        private void ValidateSignInForm()
        {
            foreach (var behavior in loginEntry.Behaviors)
            {
                BehaviorValidationUtil.ValidateBehavior<Entry>(behavior);

                if (!BehaviorValidationUtil.IsValidBehavior<Entry>(behavior))
                {
                    break;
                }
            }

            foreach (var behavior in passwordEntry.Behaviors)
            {
                BehaviorValidationUtil.ValidateBehavior<Entry>(behavior);

                if (!BehaviorValidationUtil.IsValidBehavior<Entry>(behavior))
                {
                    break;
                }
            }
        }

        private bool IsSignInFormValid()
        {
            var isLoginEntryValid = loginEntry.Behaviors.All(b => BehaviorValidationUtil.IsValidBehavior<Entry>(b));
            var isPasswordEntryValid = passwordEntry.Behaviors.All(b => BehaviorValidationUtil.IsValidBehavior<Entry>(b));

            return isLoginEntryValid && isPasswordEntryValid;
        }

        private SignInViewModel GetViewModel()
        {
            return new SignInViewModel
            {
                Login = loginEntry.Text,
                Password = passwordEntry.Text
            };
        }

        #endregion
    }
}
