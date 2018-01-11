using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElecApp.Startup))]
namespace ElecApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
