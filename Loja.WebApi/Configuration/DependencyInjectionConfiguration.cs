using Loja.Data.Repositories;
using Loja.Manager.Implementations;
using Loja.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.WebApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IMedicoService, MedicoService>();
        }
    }
}
