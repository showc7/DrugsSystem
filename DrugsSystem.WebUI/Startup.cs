using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrugsSystem.WebUI.Startup))]
namespace DrugsSystem.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
