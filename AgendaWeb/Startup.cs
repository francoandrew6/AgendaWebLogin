using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aplicacion4._1.Startup))]
namespace Aplicacion4._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
