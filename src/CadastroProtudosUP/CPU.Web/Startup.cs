using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CPU.Web.Startup))]
namespace CPU.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
