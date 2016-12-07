using Autofac;
using Common;
using Data;
using Domain.Services;

namespace Infrastructure.Configuration
{
    public class ConfigureDatabase : IBootstrapperTask<ContainerBuilder>
    {
        public void Task(ContainerBuilder configuration)
        {
            configuration.Register(context => new AppDbContext(Common.Configuration.DataBase))
                .As<IAppDbContext>()
                .InstancePerLifetimeScope();

            configuration.RegisterType<EntityRepository>().As<IRepository>();
        }
    }
}