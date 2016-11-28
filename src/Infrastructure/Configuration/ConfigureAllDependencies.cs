using Autofac;
using Common;
using Domain.Application.CommandHandlers;
using Domain.Entities;

namespace Infrastructure.Configuration
{
    public class ConfigureAllDependencies : IBootstrapperTask<ContainerBuilder>
    {
        public void Task(ContainerBuilder configuration)
        {
            configuration.RegisterAssemblyTypes(typeof(ICommand).Assembly, typeof(Test).Assembly)
                .Where(x => !typeof(ICommandHandler).IsAssignableFrom(x))
                
                .AsImplementedInterfaces()
                .AsSelf();

            configuration.RegisterAssemblyTypes(typeof(TestCreator).Assembly)
                .Where(x => typeof(ICommandHandler).IsAssignableFrom(x))
                .PropertiesAutowired()
                .As<ICommandHandler>();
        }
    }
}