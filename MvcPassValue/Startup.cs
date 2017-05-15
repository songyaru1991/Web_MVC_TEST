using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcPassValue.Startup))]
namespace MvcPassValue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
