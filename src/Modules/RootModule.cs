using Nancy;

namespace Modules
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = o => Response.AsText("Hello world");
        }
    }
}