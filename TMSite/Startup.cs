using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TMSite.Startup))]
namespace TMSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
