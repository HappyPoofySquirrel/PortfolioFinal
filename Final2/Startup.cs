using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Final2.Startup))]
namespace Final2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
