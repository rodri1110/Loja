using FluentValidation.AspNetCore;
using Loja.Manager.Validator;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.WebApi.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                    .AddFluentValidation(option =>
                    {
                        option.RegisterValidatorsFromAssemblyContaining<ClienteModelViewValidator>();
                        option.RegisterValidatorsFromAssemblyContaining<AtualizarClienteModelViewValidator>();
                        option.RegisterValidatorsFromAssemblyContaining<EnderecoModelViewValidator>();
                        option.RegisterValidatorsFromAssemblyContaining<TelefoneModelViewValidator>();
                    });
        }
    }
}
