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
            ReadOnlyDictionary<string, IPerson> people = _population.GetPeople();
            ReadOnlyCollection<string> claimants = _population.GetClaimants();

            string heir = "";
            decimal royalBlood = 0;
            foreach (string name in claimants)
            {
                if (people.TryGetValue(name, out IPerson person))
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