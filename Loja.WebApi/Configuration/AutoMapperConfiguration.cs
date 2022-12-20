using Loja.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.WebApi.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ClienteModelViewMappingProfile), typeof(AtualizarClienteModelViewMappingProfile));
        }
    }
}
