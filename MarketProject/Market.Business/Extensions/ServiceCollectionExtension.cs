using MarketProject.Business.AbstractUtilities;
using MarketProject.Business.Utilities;
using Market.Data.Concrete.EntityFramework.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Business.Abstract;
using Market.Business.Concrete;

namespace Market.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddDbContext<MarketContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);
            //services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IAuthService, AuthManager>();



            return services;
        }
    }
}
