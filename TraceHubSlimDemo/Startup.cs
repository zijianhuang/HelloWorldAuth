using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TraceHubSlimDemo.MySignalRStartup))]
namespace TraceHubSlimDemo
{
    public partial class MySignalRStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
