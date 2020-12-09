using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PhanLong.Controllers.Startup))]
namespace PhanLong.Controllers
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}