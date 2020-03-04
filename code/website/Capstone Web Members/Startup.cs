using Capstone_Web_Members;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]

namespace Capstone_Web_Members
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}