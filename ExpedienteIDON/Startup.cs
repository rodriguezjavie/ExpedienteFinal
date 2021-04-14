using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExpedienteIDON.Startup))]
namespace ExpedienteIDON
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
