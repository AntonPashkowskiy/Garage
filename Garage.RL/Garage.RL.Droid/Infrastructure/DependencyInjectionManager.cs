using XLabs.Ioc;
using Autofac;
using XLabs.Ioc.Autofac;
using Garage.BLL.Services.Interfaces;
using System.Linq;

namespace Garage.RL.Droid.Infrastructure
{
    public static class DependencyInjectionManager
    {
        #region Public Methods

        public static IResolver GetDependencyResolver()
        {
            var containerBuilder = new ContainerBuilder();

            RegisterBusinessLogicLayerServices(containerBuilder);

            return new AutofacResolver(containerBuilder.Build());
        }

        #endregion

        #region Private Methods

        private static void RegisterBusinessLogicLayerServices(ContainerBuilder containerBuilder)
        {
            var bllServiceInterfaceType = typeof(IBusinessLogicLayerService);
            var bllServicesAssembly = bllServiceInterfaceType.Assembly;
            var interfaceTypes = bllServicesAssembly.GetTypes().Where(t => t.IsInterface).ToList();
            var classTypes = bllServicesAssembly.GetTypes().Where(t => t.IsClass).ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                if (bllServiceInterfaceType.IsAssignableFrom(interfaceType))
                {
                    var implementationClass = classTypes.FirstOrDefault(c => interfaceType.IsAssignableFrom(c));
                    containerBuilder.RegisterType(implementationClass).AsImplementedInterfaces().SingleInstance();
                }
            }
        }

        #endregion
    }
}