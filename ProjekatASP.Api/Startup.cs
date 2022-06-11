using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjekatASP.Api.Core;
using ProjekatASP.Api.Emails;
using ProjekatASP.Api.Extensions;
using ProjekatASP.Application.Emails;
using ProjekatASP.Application.Logging;
using ProjekatASP.Application.UseCases;
using ProjekatASP.Implementation;
using ProjekatASP.Implementation.Emails;
using ProjekatASP.Implementation.Logging;
using ProjekatASP.Implementation.UseCaseLogger;
using System;
using System.IO;
using System.Reflection;

namespace ProjekatASP.Api
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
            var settings = new AppSettings();
            Configuration.Bind(settings);

            services.AddSingleton(settings);
            services.AddAppUser();
            services.AddJwt(settings);
            services.AddProjekatDbContext();
            services.AddUseCases();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IEmailSender>(x =>
            new SmtpEmailSender(settings.EmailOptions.FromEmail,
                                settings.EmailOptions.Password,
                                settings.EmailOptions.Port,
                                settings.EmailOptions.Host));
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjekatASP.Api", Version = "v1" });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjekatASP v1"));
            }

            app.UseRouting();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
