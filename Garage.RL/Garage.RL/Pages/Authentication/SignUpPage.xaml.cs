using Garage.RL.Managers;
using Garage.RL.Models.Authentication;
using Garage.RL.Utilities.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Garage.RL.Pages.Authentication
{
    public partial class SignUpPage : ContentPage
    {
        #region Ctor

        public SignUpPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Events Handlers

        public async Task SignUpButtonClicked(object sender, EventArgs eventArgs)
        {
            ValidateSignUpPage();

            if (IsSignUpPageValid())
            {
                await AuthenticationManager.SignUpAsync(GetViewModel());
            }
        }

        public void DrivingExpirienceSliderValueChanged(object sender, EventArgs eventArgs)
        {
            drivingExperienceSlider.Value = Math.Round(drivingExperienceSlider.Value);
        }

        #endregion

        #region Private Methods

        private bool IsSignUpPageValid()
        {
            var fieldsForValidating = new List<Entry>
            {
                nameEntry,
                loginEntry,
                emailEntry,
                passwordEntry,
                passwordConfirmationEntry,
            };
            bool isPageValid = true;

            foreach (var field in fieldsForValidating)
            {
                isPageValid = isPageValid && field.Behaviors.All(b => BehaviorValidationUtil.IsValidBehavior<Entry>(b));
            }
            return isPageValid;
        }

        private void ValidateSignUpPage()
        {
            var fieldsForValidating = new List<Entry>
            {
                nameEntry,
                loginEntry,
                emailEntry,
                passwordEntry,
                passwordConfirmationEntry,
            };

            foreach (var field in fieldsForValidating)
            {
                ValidateEntryField(field);          
            }
        }

        private void ValidateEntryField(Entry field)
        {
            foreach (var behavior in field.Behaviors)
            {
                BehaviorValidationUtil.ValidateBehavior<Entry>(behavior);

                if (!BehaviorValidationUtil.IsValidBehavior<Entry>(behavior))
                {
                    break;
                }
            }
        }

        private SignUpViewModel GetViewModel()
        {
            return new SignUpViewModel
            {
                Name = nameEntry.Text,
                Login = loginEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                DrivingExpirience = (int)drivingExperienceSlider.Value
            };
        }

        #endregion
    }
}
