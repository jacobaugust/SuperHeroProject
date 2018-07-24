using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperHeroProject.Startup))]
namespace SuperHeroProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
