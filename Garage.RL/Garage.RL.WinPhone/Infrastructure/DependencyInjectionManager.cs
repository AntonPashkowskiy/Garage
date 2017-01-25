using XLabs.Ioc;
using Autofac;
using XLabs.Ioc.Autofac;
using Garage.BLL.Services.Interfaces;
using System.Linq;
using System.Reflection;

namespace Garage.RL.WinPhone.Infrastructure
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
            var bllServiceInterfaceTypeInfo = typeof(IBusinessLogicLayerService).GetTypeInfo();
            var bllServicesAssembly = bllServiceInterfaceTypeInfo.Assembly;
            var interfaceTypes = bllServicesAssembly.ExportedTypes.Where(t => t.GetTypeInfo().IsInterface).ToList();
            var classTypes = bllServicesAssembly.ExportedTypes.Where(t => t.GetTypeInfo().IsClass).ToList();

            foreach (var interfaceType in interfaceTypes)
            {
                var interfaceTypeInfo = interfaceType.GetTypeInfo();

                if (bllServiceInterfaceTypeInfo.IsAssignableFrom(interfaceTypeInfo))
                {
                    var implementationClass = classTypes.FirstOrDefault(c => interfaceTypeInfo.IsAssignableFrom(c.GetTypeInfo()));
                    containerBuilder.RegisterType(implementationClass).AsImplementedInterfaces().SingleInstance();
                }
            }
        }

        #endregion
    }
}
