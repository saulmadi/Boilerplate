using System;
using Autofac;
using Common;
using Domain.Application.CommandHandlers;

namespace Infrastructure.Configuration
{
    public class ConfigureAllDependencies : IBootstrapperTask<ContainerBuilder>
    {
        public void Task(ContainerBuilder configuration)
        {
            configuration.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => !typeof(ICommandHandler).IsAssignableFrom(x))
                .AsImplementedInterfaces()
                .AsSelf();

            configuration.RegisterAssemblyTypes(typeof(TestCreator).Assembly)
                .Where(x => typeof(ICommandHandler).IsAssignableFrom(x))
                .As<ICommandHandler>();
        }
    }
}