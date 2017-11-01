using Microsoft.Owin;
using Owin;
using OperasWebSites;

namespace OperasWebSites
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}