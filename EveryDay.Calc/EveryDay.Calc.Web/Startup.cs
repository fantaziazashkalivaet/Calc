using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EveryDay.Calc.Web.Startup))]
namespace EveryDay.Calc.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
