using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sports_Website.Startup))]
namespace Sports_Website
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
