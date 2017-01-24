using Garage.RL.Utilities.Behaviours;
using System;
using Xamarin.Forms;

namespace Garage.RL.Behaviors.TextFields
{
    public class ValueRequiredBehavior: BaseValidatorBehavior<Entry>
    {
        #region Fields

        private Entry _bindableEntry;

        #endregion

        #region Protected Methods

        protected override void OnAttachedTo(Entry bindableEntry)
        {
            _bindableEntry = bindableEntry;
            _bindableEntry.Unfocused += BindableObjectTextFieldUnfocused;
            base.OnAttachedTo(bindableEntry);
        }

        protected override void OnDetachingFrom(Entry bindableEntry)
        {
            _bindableEntry.Unfocused -= BindableObjectTextFieldUnfocused;
            _bindableEntry = default(Entry);
            base.OnDetachingFrom(bindableEntry);
        }

        #endregion

        #region Public Methods

        public override void Validate()
        {
            ValidateEntry(_bindableEntry);
        }

        #endregion

        #region Events Handlers

        private void BindableObjectTextFieldUnfocused(object sender, EventArgs eventArgs)
        {
            var entry = sender as Entry;

            ValidateEntry(entry);
        }

        #endregion

        #region Private Methods

        private void ValidateEntry(Entry entry)
        {
            IsValid = !string.IsNullOrWhiteSpace(entry.Text);

            if (IsValid)
            {
                BehaviorStyleUtil.SetValidStyleForEntry(entry);
            }
            else
            {
                BehaviorStyleUtil.SetInvalidStyleForEntry(entry);
            }
        }

        #endregion
    }
}
