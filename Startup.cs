using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.AspNetCore.Http;

namespace canserbero
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string _crossOrigin = "_crossOrigin";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOcelot(Configuration);
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy(_crossOrigin,
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.Map("/swagger/Produccion/swagger.json", b =>
            {
                b.Run(async x =>
                {
                    var json = File.ReadAllText("swagger/swaggerprod.json");
                    await x.Response.WriteAsync(json);
                });
            });
            app.Map("/swagger/Desarrollo/swagger.json", b =>
            {
                b.Run(async x =>
                {
                    var json = File.ReadAllText("swagger/swaggerdes.json");
                    await x.Response.WriteAsync(json);
                });
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Produccion/swagger.json", "Produccion");
                c.SwaggerEndpoint("/swagger/Desarrollo/swagger.json", "Desarrollo");
            });

            app.UseCors(_crossOrigin);
            app.UseOcelot().Wait();
            app.UseMvc();
        }
    }
}
