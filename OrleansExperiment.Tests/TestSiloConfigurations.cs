using Microsoft.Extensions.DependencyInjection;
using Orleans.Hosting;
using Orleans.TestingHost;
using OrleansExperiment.Interfaces;
using OrleansExperiment.Server;

namespace OrleansExperiment.Tests
{
    public class TestSiloConfigurations : ISiloBuilderConfigurator
    {
        public void Configure(ISiloHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<ISampleGrain, SampleGrain>();
            });
        }
    }
}
