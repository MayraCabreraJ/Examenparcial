using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Programacionaplicada1.Startup))]
namespace Programacionaplicada1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
