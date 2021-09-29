using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using WebApi.Filters;

namespace WebApi
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
            services.AddApplication();

            services.AddInfrastructure(Configuration);

            //services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddControllers(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
                options.Filters.Add<BaseApiResponseFilterAttribute>();
            }).AddFluentValidation();

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

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(c =>
            {
                //var securityScheme = new OpenApiSecurityScheme
                //{
                //    Name = "JWT Authentication",
                //    Description = "Enter JWT Bearer token **_only_**",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "bearer",
                //    BearerFormat = "JWT",
                //    Reference = new OpenApiReference
                //    {
                //        Id = JwtBearerDefaults.AuthenticationScheme,
                //        Type = ReferenceType.SecurityScheme
                //    }
                //};

                //c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {securityScheme, new string[] { }}
                //});
            });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(options =>
            //{
            //    options.Audience = "/";
            //    options.Authority = "/usuario/auth";
            //});
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToLower());
                }
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

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region swagger conf
        public class SwaggerDefaultValues : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                var apiDescription = context.ApiDescription;
                operation.Deprecated |= apiDescription.IsDeprecated();

                if (operation.Parameters == null)
                    return;

                foreach (var parameter in operation.Parameters)
                {
                    var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);
                    if (parameter.Description == null)
                    {
                        parameter.Description = description.ModelMetadata?.Description;
                    }

                    if (parameter.Schema.Default == null && description.DefaultValue != null)
                    {
                        parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());
                    }

                    parameter.Required |= description.IsRequired;
                }
            }
        }

        public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
        {
            private readonly IApiVersionDescriptionProvider _provider;

            public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

            public void Configure(SwaggerGenOptions options)
            {
                foreach (var description in _provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                }
            }

            private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
            {
                var info = new OpenApiInfo()
                {
                    Title = "SMEPML API",
                    Version = description.ApiVersion.ToString(),
                };

                if (description.IsDeprecated)
                {
                    info.Description += " This API version has been deprecated.";
                }

                return info;
            }
        }

        #endregion
    }
}
