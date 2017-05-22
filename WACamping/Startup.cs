using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WACamping.Startup))]
namespace WACamping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
