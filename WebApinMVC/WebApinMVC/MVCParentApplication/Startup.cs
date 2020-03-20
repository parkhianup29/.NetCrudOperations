using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCParentApplication.Startup))]
namespace MVCParentApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
