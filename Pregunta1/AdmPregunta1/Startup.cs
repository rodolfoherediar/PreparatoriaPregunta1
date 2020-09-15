using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmPregunta1.Startup))]
namespace AdmPregunta1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
