using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Phoenix.DependencyInjection;
using Phoenix.Live.Business;
using Phoenix.Live.Business.Abstraction;
using Phoenix.Live.Business.Concretes;
using Phoenix.Live.Business.DependencyInjection;
using Phoenix.Live.DataAccess;
using Phoenix.Live.DataAccess.Abstraction;
using Phoenix.Middleware;
using Phoenix.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoenix.Live.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webEnv, IHostEnvironment env)
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Phoenix.Live.WebApi", Version = "v1" });
            });

            //services.Register<IUserRepository, UserRepository>();
            //services.Register<IPasswordRepository, PasswordRepository>();
            //services.Register<IUserService, UserManager>();
            //services.Register<IPasswordService, PasswordManager>();
            //services.Register<IFakeService, FakeManager>();
            // YA YUKARIDAKI ŞEKILDE YA DA AŞAĞIDA KI ŞEKILDE EKLENEBİLİR
            var injectorModule = new IoCModule(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Phoenix.Live.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<CustomMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
