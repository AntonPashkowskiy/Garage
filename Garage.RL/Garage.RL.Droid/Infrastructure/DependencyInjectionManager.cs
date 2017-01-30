using XLabs.Ioc;
using Autofac;
using XLabs.Ioc.Autofac;
using Garage.BLL.Services.Interfaces;
using System.Linq;
using Garage.DAL.Services.Implementations.UnitOfWork;
using Garage.DAL.Services.Interfaces.UnitOfWork;

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

        private static void RegisterDataAccessLayerServices(ContainerBuilder containerBuilder)
        {
            RegisterUnitOfWork(containerBuilder);
        }

        private static void RegisterUnitOfWork(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType(typeof(UnitOfWork)).As<IUnitOfWork>()
                            .WithParameter("pathToDatabase", DatabaseManager.GetPathToDatabase())
                            .SingleInstance();
        }

        #endregion
    }
}