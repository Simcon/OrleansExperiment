using Orleans;
using OrleansExperiment.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrleansExperiment.Server
{
    public class SampleGrain : Grain, ISampleGrain
    {
        public Task<string> Ping(string message)
        {
            Console.WriteLine($"Pinged with '{message}'");
            return Task.FromResult($"Message '{message}' received");
        }
    }
}
