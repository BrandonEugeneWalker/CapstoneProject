using Capstone_Web_Warehouse;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]

namespace Capstone_Web_Warehouse
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}