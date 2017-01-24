using Garage.RL.Utilities.Behaviours;
using System;
using Xamarin.Forms;

namespace Garage.RL.Behaviors.TextFields
{
    public class TextEqualBehavior: BaseValidatorBehavior<Entry>
    {
        #region Fields

        private Entry _bindableEntry;

        #endregion

        #region Properties

        public static readonly BindableProperty ExternalTextProperty = BindableProperty.Create("ExternalText", typeof(string), typeof(Entry), default(string));

        public string ExternalText
        {
            get
            {
                return (string)GetValue(ExternalTextProperty);
            }

            set
            {
                SetValue(ExternalTextProperty, value);
            }
        }

        #endregion

        #region Public Methods

        public override void Validate()
        {
            ValidateThatTextEqual(_bindableEntry);
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

            ValidateThatTextEqual(entry);
        }

        #endregion

        #region Private Methods

        private void ValidateThatTextEqual(Entry entry)
        {
            IsValid = entry.Text == ExternalText;

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
