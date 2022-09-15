using System.Collections.ObjectModel;
using Succession.People;

namespace Succession
{
    public class Country
    {
        public Founder Founder { get; }
        public ReadOnlyDictionary<string, IPerson> Population { get; }
        public Country(ICountryInput input)
        {
            Founder = input.GetFounder();
            Population = input.GetPeople();
        }
    }
}