using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _1___Program_y_Startup
{
    public class Program // <-- Clase inicial de ejecucion
    {
        public static void Main(string[] args) // <-- metodo principal de ejecucion, donde auto Hostea la app, y se configura.
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
