using System.Collections.ObjectModel;
using Succession.People;

namespace Succession.People
{
    public interface IPopulationInput
    {
        string GetFounder();

        ReadOnlyCollection<string> GetFamilies();

        ReadOnlyCollection<string> GetClaimants();
    }
}