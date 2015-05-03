using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SFBB.Web.Startup))]
namespace SFBB.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
