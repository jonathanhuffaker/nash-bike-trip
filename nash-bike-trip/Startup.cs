using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nash_bike_trip.Startup))]
namespace nash_bike_trip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
