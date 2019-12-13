using NUnit.Framework;
using OrleansExperiment.Interfaces;
using OrleansExperiment.Server;
using System;
using System.Threading.Tasks;

namespace OrleansExperiment.Tests
{
    public class SmokeTests : ClusterFixture
    {
        [Test]
        public async Task testing_simplegrain_with_grainfactory()
        {
            GIVEN("a grain in a cluster");
            var hello = Cluster.GrainFactory.GetGrain<ISampleGrain>(Guid.Empty);

            WHEN("invoking the grain from within the cluster");
            var greeting = await hello.Ping("Hello, World");

            THEN("should receive appropriate response.");
            Assert.AreEqual("Message 'Hello, World' received", greeting);
        }

        [Test]
        public async Task testing_simplegrain_with_client()
        {
            GIVEN("a grain in a cluster");
            var hello = Client.GetGrain<ISampleGrain>(Guid.Empty);

            WHEN("invoking the grain from outside the cluster");
            var greeting = await hello.Ping("Hello, World");

            THEN("should receive appropriate response.");
            Assert.AreEqual("Message 'Hello, World' received", greeting);
        }
    }
}
