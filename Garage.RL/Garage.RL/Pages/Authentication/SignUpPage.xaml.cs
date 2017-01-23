using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void SignUpButtonClicked(object sender, EventArgs eventArgs)
        {
        }

        public void DrivingExpirienceSliderValueChanged(object sender, EventArgs eventArgs)
        {
            drivingExperienceSlider.Value = Math.Round(drivingExperienceSlider.Value);
        }

        #endregion
    }
}
