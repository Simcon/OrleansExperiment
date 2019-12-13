using Orleans;
using System.Threading.Tasks;

namespace OrleansExperiment.Interfaces
{
    public interface IPersistentGrain : IGrainWithGuidKey
    {
        Task Write(string message);
        Task<string> Read();
    }
}
