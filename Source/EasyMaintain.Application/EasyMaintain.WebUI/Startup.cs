using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyMaintain.WebUI.Startup))]
namespace EasyMaintain.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
