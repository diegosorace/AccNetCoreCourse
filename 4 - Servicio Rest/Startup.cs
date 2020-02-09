using _4___Servicio_Rest.Clases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _4___Servicio_Rest
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
