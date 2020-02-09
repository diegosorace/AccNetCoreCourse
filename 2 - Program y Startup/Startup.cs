using _2___Program_y_Startup.Clases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _2___Program_y_Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) // <-- Este metodo se ejecuta por unica vez, y es el encargado de configurar todos los servicios que necesitamos.
        {
            services.AddControllers();

            services.AddTransient<IMiInterface, MiClaseQueImplementaInterface>();
            services.AddSingleton<IMiInterface, MiClaseQueImplementaInterface>();
            services.AddScoped<IMiInterface, MiClaseQueImplementaInterface>();

            services.AddTransient(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));
            services.AddSingleton(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));
            services.AddScoped(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // <-- Este metodo se ejecuta una vez por cada request que entra y es el encargado de configurar todos los midleware que necesitemos.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
