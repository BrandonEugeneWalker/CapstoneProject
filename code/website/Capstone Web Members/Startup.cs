using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capstone_Web_Members.Startup))]
namespace Capstone_Web_Members
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
