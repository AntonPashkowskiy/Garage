using Garage.RL.Utilities.Behaviours;
using System;
using Xamarin.Forms;

namespace Garage.RL.Behaviours.TextFields
{
    public class ValueRequiredBehavior: Behavior<Entry>
    {
        #region Protected Methods

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += BindableObjectTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= BindableObjectTextChanged;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Events Handlers

        private void BindableObjectTextChanged(object sender, EventArgs eventArgs)
        {
            var entry = sender as Entry;

            if (string.IsNullOrWhiteSpace(entry.Text))
            {
                BehaviorStyleUtil.SetInvalidStyleForTextField(entry);
            }
            else
            {
                BehaviorStyleUtil.SetValidStyleForTextField(entry);
            }
        }

        #endregion
    }
}
