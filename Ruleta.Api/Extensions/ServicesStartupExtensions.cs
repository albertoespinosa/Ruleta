using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ruleta.Core.Services;
using Ruleta.Core.Interfaces;
using Ruleta.Infrastructure.Data;
using Ruleta.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruleta.Api.Extensions
{
    public static class ServicesStartupExtensions
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RuletaDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("RuletaConnectionString"))
        );

            return services;
        }

        public static IServiceCollection ConfigureDIServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IJuegoRuletaService, JuegoRuletaService>();
            services.AddTransient<IApuestaService, ApuestaService>();           

            return services;
        }
    }
}
