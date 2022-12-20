using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Loja.WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo
                    {
                        Title = "Loja",
                        Version = "v1",
                        Description = "API da aplicação Loja.",
                        Contact = new OpenApiContact
                        {
                            Name = "Rodrigo Oliveira",
                            Email = "rodri.oliveira1110@gmail.com",
                            Url = new Uri("https://github.com/rodri1110")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        },
                        TermsOfService = new Uri("https://opensource.org/osd")
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                xmlPath = Path.Combine(AppContext.BaseDirectory, "Loja.Core.Shared.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddFluentValidationRulesToSwagger();

        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint("./swagger/v1/swagger.json", "Loja V1");
                }
            );
        }
    }
}
