using Garage.RL.Utilities.Behaviours;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Garage.RL.Behaviors.TextFields
{
    public class EmailValidBehavior: BaseValidatorBehavior<Entry>
    {
        #region Fields

        private Entry _bindableEntry;
        private const string _emailValidationRegexp = @"^(\S+)@([a-z0-9-]+)(\.)([a-z]{2,4})(\.?)([a-z]{0,4})+$";

        #endregion

        #region Public Methods

        public override void Validate()
        {
            ValidateEmailEntry(_bindableEntry);
        }

        #endregion

        #region Protected Methods

        protected override void OnAttachedTo(Entry bindable)
        {
            _bindableEntry = bindable;
            _bindableEntry.Unfocused += BindableObjectTextFieldUnfocused;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            _bindableEntry.Unfocused -= BindableObjectTextFieldUnfocused;
            _bindableEntry = default(Entry);
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Event Handlers

        private void BindableObjectTextFieldUnfocused(object sender, EventArgs eventArgs)
        {
            var entry = sender as Entry;

            ValidateEmailEntry(entry);
        }

        #endregion

        #region Private Methods

        private void ValidateEmailEntry(Entry emailEntry)
        {
            IsValid = !string.IsNullOrWhiteSpace(emailEntry.Text) && Regex.IsMatch(emailEntry.Text, _emailValidationRegexp);

            if (IsValid)
            {
                BehaviorStyleUtil.SetValidStyleForEntry(emailEntry);
            }
            else
            {
                BehaviorStyleUtil.SetInvalidStyleForEntry(emailEntry);
            }
        }

        #endregion
    }
}
