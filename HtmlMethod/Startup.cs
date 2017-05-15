using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HtmlMethod.Startup))]
namespace HtmlMethod
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
