using Nancy;

namespace Modules
{
    public class RootModule:NancyModule
    {
        public RootModule()
        {
            Get["/"] = o =>
            {
                return Response.AsText("Hello world");
            };
        }
    }
}