using Succession.People;

namespace Succession
{
    public class Country
    {
        public Founder Founder { get; }
        public Country(ICountryInput input)
        {
            Founder = input.GetFounder();
        }
    }
}