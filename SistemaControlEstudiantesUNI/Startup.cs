using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaControlEstudiantesUNI.Startup))]
namespace SistemaControlEstudiantesUNI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
