using Xamarin.Forms;

namespace Garage.RL.Utilities.Behaviours
{
    public class BehaviorStyleUtil
    {
        #region Public Methods

        public static void SetInvalidStyleForEntry(Entry textField)
        {
            textField.PlaceholderColor = Color.Red;
            textField.TextColor = Color.Red;
        }

        public static void SetValidStyleForEntry(Entry textField)
        {
            textField.PlaceholderColor = Color.Default;
            textField.TextColor = Color.Default;
        }

        #endregion
    }
}
