using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRDCRfriend.WebMVC.Startup))]
namespace PRDCRfriend.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
