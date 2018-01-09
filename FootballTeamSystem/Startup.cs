using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FootballTeamSystem.Startup))]
namespace FootballTeamSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
