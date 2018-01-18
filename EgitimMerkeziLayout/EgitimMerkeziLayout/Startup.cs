using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EgitimMerkeziLayout.Startup))]
namespace EgitimMerkeziLayout
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
