using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarkdownDeepSample2013.Startup))]
namespace MarkdownDeepSample2013
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
