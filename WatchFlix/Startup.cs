using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WatchFlix.Startup))]
namespace WatchFlix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
