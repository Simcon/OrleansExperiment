using Orleans;
using Orleans.TestingHost;
using System;

namespace OrleansExperiment.Tests
{
    public class ClusterFixture : IDisposable
    {
        public ClusterFixture()
        {
            var builder = new TestClusterBuilder();
            builder.AddSiloBuilderConfigurator<TestSiloConfigurations>();
            this.Cluster = builder.Build();
            this.Cluster.Deploy();
            this.Cluster.InitializeClient();
            this.Client = Cluster.Client;
        }

        public void Dispose()
        {
            this.Cluster.StopAllSilos();
        }

        public readonly TestCluster Cluster;
        public readonly IClusterClient Client;

        protected void GIVEN(string text)
        {
            Console.WriteLine($"GIVEN {text}");
        }

        protected void WHEN(string text)
        {
            Console.WriteLine($"WHEN {text}");
        }

        protected void THEN(string text)
        {
            Console.WriteLine($"THEN {text}");
        }

        protected void PrintLine(string text)
        {
            Console.WriteLine($"     {text}");
        }
    }
}
