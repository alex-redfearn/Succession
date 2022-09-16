using System.Collections.Generic;

namespace Succession.People
{
    public class Founder : IPerson
    {
        public decimal RoyalBlood { get; }
        public string Name { get; private set; }
        public List<Royal> Children { get; }

        public Founder(string name)
        {
            Name = name;
            // Founders royal blood is always 1 (max).
            RoyalBlood = 1;
            Children = new List<Royal>();
        }
    }
}