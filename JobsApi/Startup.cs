using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsApi.Data;
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

namespace JobsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JobsApi", Version = "v1" });
            });
            services.AddSingleton<IConfig>(
                Configuration
                    .GetSection("CustomConfig")?
                    .Get<Config>());
            AddDbContext(services);            
        }
        private void AddDbContext(IServiceCollection services)
        {
            var debugLogging = new Action<DbContextOptionsBuilder>(
                opt =>
                {
                    #if DEBUG
                    //This will log EF-generated SQL commands to the console.
                    opt.UseLoggerFactory(LoggerFactory.Create(
                        builder => 
                        {
                            builder.AddConsole();
                        }));
                        //This will log the params for those commands
                    opt.EnableSensitiveDataLogging();
                    opt.EnableDetailedErrors();
                    #endif
                });
                
            services.AddDbContext<JobsContext>(
                opt => 
                {
                    //sqldb-job == name of the FUTURE docker container
                    var connStr = Configuration.GetConnectionString("sqldb-job") ?? "name=Job";
                    opt.UseSqlServer(connStr, opt => opt.EnableRetryOnFailure(5));
                    debugLogging(opt);
                }, ServiceLifetime.Transient);            
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JobsApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
