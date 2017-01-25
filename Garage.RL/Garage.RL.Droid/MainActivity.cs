using Android.App;
using Android.Content.PM;
using Android.OS;
using Garage.RL.Configuration;
using XLabs.Ioc;
using Garage.RL.Droid.Infrastructure;

namespace Garage.RL.Droid
{
    [Activity(Label = "Garage.RL", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            var dependencyResolver = DependencyInjectionManager.GetDependencyResolver();
            Resolver.SetResolver(dependencyResolver);
            LoadApplication(new App(new AppConfigurator(dependencyResolver)));
        }
    }
}

