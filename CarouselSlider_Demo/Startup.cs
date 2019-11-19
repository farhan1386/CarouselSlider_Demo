using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarouselSlider_Demo.Startup))]
namespace CarouselSlider_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
