using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Runtime;
using Candela.Api.Common;

namespace Candela.Api.Deployment
{
    public class Startup : StartupBase
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment app) : base(env, app)
        {
        }

        //
        // This method gets called by a runtime.
        // Use this method to add services to the container
        //
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

        }

        //
        // Configure is called after ConfigureServices is called.
        //
        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);

            //
            // TODO: any API specific configuration
            //
        }
    }
}
