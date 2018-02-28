using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cafe_Website.Startup))]
namespace Cafe_Website
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
