using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Overloadings.Startup))]
namespace Overloadings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
