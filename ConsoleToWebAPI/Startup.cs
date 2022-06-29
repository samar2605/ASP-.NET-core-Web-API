using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware1>();
        }
        public void Configure(IApplicationBuilder app ,IWebHostEnvironment env)
        {

/*            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use-1 1\n");
                await next();
                await context.Response.WriteAsync("Hello from Use-2 2\n");

            });

            app.UseMiddleware<CustomMiddleware1>();
            //Map method is used when we want some middleware logic only for specific route, it creates a new branch and execute
            app.Map("/hello", HelloFunc);
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use-1 1\n");
                await next();
                await context.Response.WriteAsync("Hello from Use-2 2\n");

            });

            app.Run(async context=>
            {
                await context.Response.WriteAsync("Hello\n");
            });*/
            //Hello 2 will not work since after the first Run() method code execution stop
            //since it completes the middleware execution
            /*app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello 2");
            });*/
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints=>
            {
                endpoints.MapControllers();
                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello from a new Web API");
                });
                endpoints.MapGet("/test", async context =>
                {
                    await context.Response.WriteAsync("Hello from a new Web API test");
                });*/
            });
        }

        private void HelloFunc(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from map 1\n");
   
            });
        }
    }
}
