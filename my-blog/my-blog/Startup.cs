using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(my_blog.Startup))]
namespace my_blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
