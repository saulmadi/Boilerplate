using Autofac;
using Common;
using Domain.Entities;

namespace Infrastructure.Configuration
{
    public class ConfigureAllDependencies : IBootstrapperTask<ContainerBuilder>
    {
        public void Task(ContainerBuilder configuration)
        {
            configuration.RegisterAssemblyTypes(typeof(ICommand).Assembly, typeof(Entity).Assembly)
                .Where(x => !typeof(ICommandHandler).IsAssignableFrom(x))
                .AsImplementedInterfaces()
                .AsSelf();

            configuration.RegisterAssemblyTypes(typeof(Entity).Assembly)
                .Where(x => typeof(ICommandHandler).IsAssignableFrom(x))
                .PropertiesAutowired()
                .As<ICommandHandler>();
        }
    }
}