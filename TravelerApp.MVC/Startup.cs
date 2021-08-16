using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelerApp.MVC.Startup))]
namespace TravelerApp.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
