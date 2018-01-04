using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConferenceTracker.Startup))]
namespace ConferenceTracker
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
