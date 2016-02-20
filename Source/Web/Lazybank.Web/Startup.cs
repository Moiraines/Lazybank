using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(Lazybank.Web.Startup))]

namespace Lazybank.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
