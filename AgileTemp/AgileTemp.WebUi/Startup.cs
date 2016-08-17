using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgileTemp.WebUi.Startup))]
namespace AgileTemp.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
