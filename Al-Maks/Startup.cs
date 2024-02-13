using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Al_Maks.Startup))]
namespace Al_Maks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
