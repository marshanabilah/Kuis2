using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kuis2.Startup))]
namespace Kuis2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
