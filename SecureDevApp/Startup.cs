using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecureDevApp.Startup))]
namespace SecureDevApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
