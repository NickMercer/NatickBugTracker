﻿using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(BugTracker.Startup))]
namespace BugTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
