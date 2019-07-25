using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YouStar.WebUI.Startup))]
namespace YouStar.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
