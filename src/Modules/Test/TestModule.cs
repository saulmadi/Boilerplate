using Common;
using Domain.Application.Commands;
using Nancy;
using Nancy.ModelBinding;

namespace Modules.Test
{
    public class TestModule : NancyModule
    {
        public TestModule(ICommandDispatcher commandDispatcher) : base("/tests")
        {
            Post["", true] = async (o, token) =>
            {
                var request = this.Bind<TestRequest>();

                await commandDispatcher.Dispatch(new CreateTest(request.Name));
                return null;
            };
        }
    }
}