using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sefin.AskMe.WebFormApp.Startup))]
namespace Sefin.AskMe.WebFormApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
        }
    }
}
