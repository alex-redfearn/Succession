using System.Collections.ObjectModel;
using Succession.People;

namespace Succession
{
    public class Country
    {
        private readonly Population _population;
        public Country(Population population)
        {
            _population = population;
        }

        public string GetHeir()
        {
            Founder founder = _population.GetFounder();
            ReadOnlyDictionary<string, IPerson> descendants = _population.GetDescendants(founder);

            string heir = "";
            decimal royalBlood = 0;
            foreach (string name in _population.GetClaimants())
            {
                if (descendants.TryGetValue(name, out IPerson person))
                {
                    if(person.RoyalBlood > royalBlood)
                    {
                        heir = person.Name;
                        royalBlood = person.RoyalBlood;
                    }
                }
            }

            return heir;
        }
    }
}