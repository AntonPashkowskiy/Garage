using Garage.RL.Managers;
using Garage.RL.Pages.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Garage.RL.Pages
{
    public partial class MainProfilePage : ContentPage
    {
        #region Ctor

        public MainProfilePage()
        {
            InitializeComponent();
        }

        #endregion

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!AuthenticationManager.IsUserAuthenticated)
            {
                Navigation.PushModalAsync(new GreetingPage());
            }
        }

        #endregion
    }
}
