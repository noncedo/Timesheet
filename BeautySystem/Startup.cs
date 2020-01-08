using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeautySystem.Startup))]
namespace BeautySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
