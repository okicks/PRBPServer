using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PRBPServer.Startup))]

namespace PRBPServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
