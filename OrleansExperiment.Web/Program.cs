using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;

namespace OrleansExperiment.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseOrleans(builder =>
                {
                    // Enable dashboard:
                    // the dashboard registers its services and grains using ConfigureApplicationParts 
                    // which disables the automatic discovery of grains in Orleans. To enable automatic 
                    // discovery of the grains of the original project, change the configuration to
                    // use AddFromApplicationBaseDirectory
                    builder.ConfigureApplicationParts(parts => parts.AddFromApplicationBaseDirectory());
                    builder.UseDashboard(options => { });

                    // Use in-memory storage
                    builder.AddMemoryGrainStorage("profileStore");
                    builder.UseLocalhostClustering();
                });
    }
}
