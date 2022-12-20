using FluentValidation.AspNetCore;
using Loja.Data.Context;
using Loja.Data.Repositories;
using Loja.Manager.Implementations;
using Loja.Manager.Interfaces;
using Loja.Manager.Mappings;
using Loja.Manager.Validator;
using Loja.WebApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.WebApi
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
            services.AddControllers();

            services.AddFluentValidationConfiguration();

            //Configurando nossa string de conexão
            services.AddDataBaseConfiguration(Configuration);

            //Instancia repositório, toda vez que chamar a interface
            services.AddDependencyInjectionConfiguration();

            services.AddAutoMapperConfiguration();

            services.AddSwaggerConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //As exceções são tratadas no retorno e será tratada no retorno passando por env.IsDevelopment, se for posicionada abaixo da variável de ambiente de Dev ela será exibida ou caso o ambiente seja diferente de desenvolvimento.
            app.UseExceptionHandler("/error");

            //condicional para utilizar exception de dev
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDataBaseConfiguration();

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
