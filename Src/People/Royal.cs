using System;
using System.Collections.Generic;
using System.Linq;

namespace Succession.People
{
    public class Royal : IPerson
    {
        // Ranges from 0 to 1.
        private decimal _royalBlood = 0;
        public decimal RoyalBlood
        {
            get { return _royalBlood; }
        }
        public string Name { get; private set; }
        public IPerson ParentOne { get; set; }
        public IPerson ParentTwo { get; set; }
        public List<Royal> Children { get; }

        public Royal(string name, IPerson parentOne, IPerson parentTwo)
        {
            Name = name;
            ParentOne = parentOne;
            ParentTwo = parentTwo;
            Children = new List<Royal>();
        }

        public void SetRoyalBlood()
        {
            // A person gets half the blood from the father and the other half from the mother.
            _royalBlood = (ParentOne.RoyalBlood + ParentTwo.RoyalBlood) / 2;
        }
    }
}