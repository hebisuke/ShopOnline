using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoAn_ShopOnline.Startup))]
namespace DoAn_ShopOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
