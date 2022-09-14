namespace Succession.People
{
    public class Founder : IPerson
    {
        public string Name { get; private set; }
        public decimal RoyalBlood { get; private set; }

        public Founder(string name)
        {
            Name = name;
            RoyalBlood = 1;
        }
    }
}