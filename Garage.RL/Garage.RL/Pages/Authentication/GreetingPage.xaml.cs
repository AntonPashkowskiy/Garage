using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Garage.RL.Pages.Authentication
{
    public partial class GreetingPage : ContentPage
    {
        #region Ctor

        public GreetingPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Events Handlers

        public void SignInButtonClicked(object sender, EventArgs eventArgs)
        {
            Navigation.PushModalAsync(new SignInPage());
        }

        public void SignUpButtonClicked(object sender, EventArgs eventArgs)
        {
            Navigation.PushModalAsync(new SignUpPage());
        }

        #endregion
    }
}
