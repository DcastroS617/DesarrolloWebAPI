using DesarrolloWebAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesarrolloWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public readonly string _MyCors = "LaGataJuanita1.0";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            
            services.AddCors(option => option.AddPolicy(name: _MyCors,
                builder => builder.SetIsOriginAllowed(uri => new Uri(uri).Host == "localhost")
                .AllowAnyHeader()
                .AllowAnyMethod()));
            //services.AddDbContext<InMemoryContext>(context =>
            //context.UseInMemoryDatabase("InMemory"));
            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc("v1", new() { Title = "DesarrolloWebAPI", Version = "v1" });
            });
            services.AddDbContext<SQLDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConexionSQL")));//Inyeccion de dependencia bd
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desarrollo Web API");
                    //c.RoutePrefix = string.Empty;
                });
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors(_MyCors);

            app.UseAuthorization();          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
