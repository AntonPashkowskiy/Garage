using Xamarin.Forms;

namespace Garage.RL.Behaviors
{
    public abstract class BaseValidatorBehavior<T>: Behavior<T> where T: BindableObject
    {
        #region Properties

        public static readonly BindableProperty IsValidProperty = BindableProperty.Create("IsValid", typeof(bool), typeof(T), default(bool));

        public bool IsValid
        {
            get
            {
                return (bool)GetValue(IsValidProperty);
            }

            protected set
            {
                SetValue(IsValidProperty, value);
            }
        }

        #endregion

        #region Public Methods

        public abstract void Validate();

        #endregion
    }
}
