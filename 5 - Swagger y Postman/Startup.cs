using _5___Swagger_y_Postman.Clases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models; 

namespace _5___Swagger_y_Postman
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IMiInterface, MiClaseQueImplementaInterface>();
            services.AddSingleton<IMiInterface, MiClaseQueImplementaInterface>();
            services.AddScoped<IMiInterface, MiClaseQueImplementaInterface>();

            services.AddTransient(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));
            services.AddSingleton(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));
            services.AddScoped(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));

            //Instalamos los nuget correspondientes, y agregamos el servicio de swagger.
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "V1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Agregamos el midleware 
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
