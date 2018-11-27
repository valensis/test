using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecureStudentManager.Startup))]
namespace SecureStudentManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
