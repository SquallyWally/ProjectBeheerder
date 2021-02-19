using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectBeheerder.Startup))]
namespace ProjectBeheerder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
