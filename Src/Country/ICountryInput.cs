using System.Collections.ObjectModel;
using Succession.People;

namespace Succession
{
    public interface ICountryInput
    {
        Founder GetFounder();

        ReadOnlyDictionary<string, IPerson> GetPeople();
    }
}