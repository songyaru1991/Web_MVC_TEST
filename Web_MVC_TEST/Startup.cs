using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_MVC_TEST.Startup))]
namespace Web_MVC_TEST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
