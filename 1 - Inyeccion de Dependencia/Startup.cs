using _1___Inyeccion_de_Dependencia.Clases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _1___Inyeccion_de_Dependencia
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //<-- Inyecion de configuracion
        {
            Configuration = configuration; //<-- encapsulamiento
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Como crear nuestras propias inyecciones de dependencia.
            services.AddTransient<IMiInterface, MiClaseQueImplementaInterface>(); //<-- Entrega una nueva instancia cada ves que la pedimos.
            services.AddSingleton<IMiInterface, MiClaseQueImplementaInterface>(); //<-- Genera una instancia por request y entrega esa misma a lo largo de la vida del request
            services.AddScoped<IMiInterface, MiClaseQueImplementaInterface>();    //<-- Genera una instancia por servicio y entrega la misma a todos los request que llegan.

            //Como se declaran si se usan clases e interfaces genericas.
            services.AddTransient(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));
            services.AddSingleton(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));
            services.AddScoped(typeof(IMiInterfaceGenerica<>), typeof(MiClaseQueImplementaInterfaceGenerica<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
