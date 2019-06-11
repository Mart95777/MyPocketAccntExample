using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCurrencyPocketbook.Startup))]
namespace MyCurrencyPocketbook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
