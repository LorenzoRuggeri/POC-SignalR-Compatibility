using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppWithAuthentication.Startup))]
namespace WebAppWithAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
