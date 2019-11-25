using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PWEB01B.Startup))]
namespace PWEB01B
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
