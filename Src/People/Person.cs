namespace Succession.People
{
    public class Person : IPerson
    {
        public string Name { get; private set; }
        public decimal RoyalBlood { get; private set; }

        public Person(string name)
        {
            Name = name;
            RoyalBlood = 0;
        }
    }
}