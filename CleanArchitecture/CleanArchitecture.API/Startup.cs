using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Application.UseCases;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Agregar Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                
                {
                    Title = "Clean Architecture API",
                    Version = "v1",
                    Description = "API siguiendo Clean Architecture con ASP.NET Core",
                    Contact = new OpenApiContact
                    {
                        Name = "Tu Nombre",
                        Email = "tucorreo@example.com",
                        Url = new Uri("https://github.com/tu-repositorio")
                    }
                });
            });
            // Inyección de dependencias
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddScoped<CreateUserUseCase>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ✅ Habilitar Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Architecture API v1");
                c.RoutePrefix = string.Empty; // Para acceder en la raíz (http://localhost:5000/)
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}