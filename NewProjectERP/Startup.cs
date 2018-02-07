using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewProjectERP.Startup))]
namespace NewProjectERP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
