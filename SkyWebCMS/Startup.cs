using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkyWebCMS.Startup))]
namespace SkyWebCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
