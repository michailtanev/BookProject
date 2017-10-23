using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolBookApplication.Web.Startup))]
namespace SchoolBookApplication.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
