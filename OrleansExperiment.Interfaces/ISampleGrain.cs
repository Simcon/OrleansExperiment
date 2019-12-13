using Orleans;
using System.Threading.Tasks;

namespace OrleansExperiment.Interfaces
{
    public interface ISampleGrain : IGrainWithGuidKey
    {
        Task<string> Ping(string message);
    }
}
