using _6___Logging.Clases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace _6___Logging
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

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "V1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "post API V1");
            });

            loggerFactory.AddFile(Configuration.GetSection("Logging")); // <-- Podemos indicar si ademas de la consola queres usar un archivo de log.

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
