using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminView.Startup))]
namespace AdminView
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
