using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrugsSystem.Startup))]
namespace DrugsSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
