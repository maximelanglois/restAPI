using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using restapi.Models;

namespace restapi
{
    public class Startup
    {
        public IConfiguration Configuration {get;}

        public Startup(IConfiguration configuration) => Configuration = configuration;

        /* 
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        */

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<batteryContext>
                // (opt => opt.UseMySql(Configuration["data:APIconnection:ConnectionString"]));
            // services.AddDbContext<columnContext>
                // (opt => opt.UseMySql(Configuration["data:APIconnection:ConnectionString"]));
            // services.AddDbContext<elevatorContext>
                // (opt => opt.UseMySql(Configuration["data:APIconnection:ConnectionString"]));
            // services.AddDbContext<leadContext>
                // (opt => opt.UseMySql(Configuration["data:APIconnection:ConnectionString"]));
            // services.AddDbContext<customerContext>
                // (opt => opt.UseMySql(Configuration["data:APIconnection:ConnectionString"]));
            services.AddDbContext<mySQLContext>
                (opt => opt.UseMySql(Configuration["data:APIconnection:ConnectionString"]));    

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
