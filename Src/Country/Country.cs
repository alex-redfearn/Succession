using System.Collections.ObjectModel;
using Succession.People;

namespace Succession
{
    public class Country
    {
        private readonly ICountryInput _input;
        public Country(ICountryInput input)
        {
            _input = input;
        }

        public string GetHeir()
        {
            Founder founder = new Founder(_input.GetFounder(), _input.GetFamilyTree());
            ReadOnlyDictionary<string, IPerson> descendants = founder.Descendants;
            
            string heir = string.Empty;
            decimal royalBlood = decimal.Zero;
            foreach (string name in _input.GetClaimants())
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