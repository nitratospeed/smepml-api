using Application.Common.Interfaces;
using Application.Common.Models;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            services.AddScoped<IAzureMLService, AzureMLService>();
            services.AddScoped<IMailKitService, MailKitService>();
            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddTransient<IDateTime, DateTimeService>();

            AppSettingsKeys.Issuer = configuration["AppSettings:Issuer"];
            AppSettingsKeys.Key = configuration["AppSettings:Key"];

            return services;
        }
    }
}
