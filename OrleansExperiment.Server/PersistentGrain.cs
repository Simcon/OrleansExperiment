using Orleans;
using Orleans.Runtime;
using OrleansExperiment.Interfaces;
using System;
using System.Threading.Tasks;

namespace OrleansExperiment.Server
{
    public class PersistentGrain : Grain, IPersistentGrain
    {
        private readonly IPersistentState<SomeState> _profile;

        public PersistentGrain([PersistentState("profile", "profileStore")] IPersistentState<SomeState> profile)
        {
            _profile = profile;
        }

        public async Task Write(string firstName)
        {
            _profile.State.FirstName = firstName;
            await _profile.WriteStateAsync();
            Console.WriteLine($"Saved: '{firstName}'");

            // Deactivate the grain on idle. We do this so the 
            // grain has to reactivate when we call Read (put a 
            // breakpoint on the constructor to confirm) otherwise we just
            // read from the active grain and aren't really testing persistence.
            // when clicking the Read button.
            this.DeactivateOnIdle();
        }

        public async Task<string> Read()
        {
            var firstName = _profile.State.FirstName;
            return await Task.FromResult(firstName);
        }
    }

    public class SomeState
    {
        public string FirstName { get; set; }
    }
}
