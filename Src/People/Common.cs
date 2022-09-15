using System.Collections.Generic;
using System.Linq;

namespace Succession.People
{
    public class Common : IPerson
    {
        public decimal RoyalBlood { get; }    
        public string Name { get; private set; }
        public List<Royal> Children { get; }

        public Common()
        {
            Name = "Unknown";
            RoyalBlood = 0;
            Children = new List<Royal>();
        }
    }
}