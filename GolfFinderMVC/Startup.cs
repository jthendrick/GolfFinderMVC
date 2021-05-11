using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GolfFinderMVC.Startup))]
namespace GolfFinderMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
