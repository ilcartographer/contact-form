using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contact_Form.Startup))]
namespace Contact_Form
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
