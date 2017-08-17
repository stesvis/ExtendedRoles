using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExtendedRoles.Startup))]
namespace ExtendedRoles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
