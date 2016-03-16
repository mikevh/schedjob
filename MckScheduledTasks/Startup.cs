using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MckScheduledTasks.Startup))]
namespace MckScheduledTasks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
