using System.Collections.ObjectModel;

namespace Succession
{
    public interface ICountryInput
    {
        string GetFounder();

        ReadOnlyCollection<string> GetFamilyTree();

        ReadOnlyCollection<string> GetClaimants();
    }
}