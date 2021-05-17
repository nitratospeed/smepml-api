using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SMEPMLBack.Core.Interfaces;
using SMEPMLBack.Core.Interfaces.Repositories;
using SMEPMLBack.Core.Interfaces.Services;
using SMEPMLBack.Infrastructure;
using SMEPMLBack.Infrastructure.Repositories;
using SMEPMLBack.Infrastructure.Services;
using SMEPMLBack.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMEPMLBack.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("SMEPMLBack.Infrastructure"))
                );

            services.AddScoped<ISintomaRepository, SintomaRepository>();
            services.AddScoped<IEnfermedadRepository, EnfermedadRepository>();

            services.AddScoped<ISintomaService, SintomaService>();
            services.AddScoped<IEnfermedadService, EnfermedadService>();
            services.AddScoped<IModelService, ModelService>();

            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddSwaggerGen();
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMEPML API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.Use((context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "Deny");
                context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
                context.Response.Headers.Add("Permissions-Policy", "geolocation=(), midi=(), camera=(),usb=(), magnetometer=(), sync-xhr=(), microphone=(), camera=(), gyroscope=(), speaker=(), payment=()");
                context.Response.Headers.Add("Content-Security-Policy", "default-src https:; style-src https:; img-src https: data:; font-src https: data:; script-src https:; connect-src https:; frame-ancestors https:; form-action https:; base-uri https:; object-src 'none'");
                context.Response.Headers.Add("Expect-CT", "max-age=0");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
                //context.Response.Headers.Add("Cache-Control", "private, no-cache, no-store, must-revalidate, max-age=0");
                //context.Response.Headers.Add("Pragma", "no-cache");
                //context.Response.Headers.Add("Expires", "0");
                return next.Invoke();
            });

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
