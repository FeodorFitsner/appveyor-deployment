#define ENABLE_SWAGGER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Runtime;

namespace Candela.Api.Common
{
    public abstract class StartupBase
    {
        public IConfiguration Configuration
        {
            get; protected set;
        }

        protected StartupBase(IHostingEnvironment env, IApplicationEnvironment app)
        {
            this.Configuration = new ConfigurationBuilder(app.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();

            //
            // TODO: doesn't seem to be injected yet
            //
            /*
            if (env.IsDevelopment)
            {
                Configuration.AddApplicationInsightsSettings(developerMode: true);
            }
            */
        }

        //
        // This method gets called by a runtime.
        // Use this method to add services to the container
        //
        public virtual void ConfigureServices(IServiceCollection services)
        {
#if ENABLE_SWAGGER
            services.AddSwagger();
#endif

            services.AddMvc();
            services.AddSingleton(_ => this.Configuration);

            services.AddLogging();
        }

        //
        // Configure is called after ConfigureServices is called.
        //
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //
            // Configure the HTTP request pipeline.
            //

            //
            // Add MVC to the request pipeline.
            //
            app.UseMvc();

            //
            // Track HTTP request telemetry data
            //
#if ENABLE_SWAGGER
            //
            // needed to massage default Swashbuckle route
            //
            app.UseSwagger("swagger/docs/{apiVersion}");
            app.UseSwaggerUi();
#endif
        }
    }
}
