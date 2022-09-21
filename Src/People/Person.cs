namespace Succession.People
{
    public class Person : IPerson
    {
        public decimal RoyalBlood
        {
            get
            {
                return GetRoyalBlood();
            }
        }
        public string Name { get; private set; }
        public IPerson ParentOne { get; set; }
        public IPerson ParentTwo { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person(string name, IPerson parentOne, IPerson parentTwo)
        {
            Name = name;
            ParentOne = parentOne;
            ParentTwo = parentTwo;
        }

        public decimal GetRoyalBlood()
        {
            // A person gets half the blood from the father and the other half from the mother.
            if (ParentOne != null && ParentTwo != null)
            {
                return (ParentOne.RoyalBlood + ParentTwo.RoyalBlood) / 2;
            }

            return 0;
        }
    }
}