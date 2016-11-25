using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;

namespace Infrastructure
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        private static readonly Action<Response> CorsResponse = x =>
        {
            x.WithHeader("Access-Control-Allow-Methods",
                "GET, POST, PUT, DELETE, OPTIONS");
            x.WithHeader("Access-Control-Allow-Headers",
                "Content-Type, Accept, Authorization ");
            x.WithHeader("Access-Control-Max-Age", "1728000");
            x.WithHeader("Access-Control-Allow-Origin", "*");
        };

        private readonly List<IBootstrapperTask<ContainerBuilder>> _tasks;

        public Bootstrapper()
        {
            _tasks = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IBootstrapperTask<ContainerBuilder>).IsAssignableFrom(x))
                .Select(Activator.CreateInstance)
                .Cast<IBootstrapperTask<ContainerBuilder>>()
                .ToList();
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope existingContainer)
        {
            var builder = new ContainerBuilder();
            _tasks.ForEach(task => task.Task(builder));
            builder.Update(existingContainer.ComponentRegistry);
            base.ConfigureApplicationContainer(existingContainer);
        }

        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline(x => CorsResponse(x.Response));

            base.RequestStartup(container, pipelines, context);
        }
    }
}