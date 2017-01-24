using Garage.RL.Behaviors;
using Xamarin.Forms;

namespace Garage.RL.Utilities.Behaviours
{
    public static class BehaviorValidationUtil
    {
        #region Public Methods

        public static bool IsValidBehavior<T>(Behavior behavior) where T: BindableObject
        {
            var validatorBehavior = behavior as BaseValidatorBehavior<T>;
            return validatorBehavior == null ? true : validatorBehavior.IsValid;
        }

        public static void ValidateBehavior<T>(Behavior behavior) where T: BindableObject
        {
            var validatorBehavior = behavior as BaseValidatorBehavior<T>;

            if (validatorBehavior != null)
            {
                validatorBehavior.Validate();
            }
        }

        #endregion
    }
}
