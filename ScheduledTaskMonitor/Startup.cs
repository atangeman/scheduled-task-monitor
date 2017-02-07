using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

using Owin;

[assembly: OwinStartup(typeof(ScheduledTaskMonitor.Startup))]

namespace ScheduledTaskMonitor
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/User/Login")
            });
        }

    }
}
