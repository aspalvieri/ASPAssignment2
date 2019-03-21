using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPAssignment2.Startup))]
namespace ASPAssignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
