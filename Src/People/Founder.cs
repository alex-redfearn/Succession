using System.Collections.Generic;
using System.Collections.ObjectModel;
using Succession.Util;

namespace Succession.People
{
    public class Founder : IPerson
    {
        private readonly ReadOnlyCollection<string> _familyTree;
        private readonly decimal _royalBlood = 1;

        public decimal RoyalBlood
        {
            get
            {
                return _royalBlood;
            }
        }
        public string Name { get; private set; }
        public ReadOnlyDictionary<string, IPerson> Descendants { get { return GetDescendants(); } }

        public Founder(string name, ReadOnlyCollection<string> familyTree)
        {
            Name = name;
            _familyTree = familyTree;
        }

        private ReadOnlyDictionary<string, IPerson> GetDescendants()
        {
            Dictionary<string, IPerson> people = new Dictionary<string, IPerson>() { { Name, this } };

            foreach (string family in _familyTree)
            {
                string[] familyMembers = SplitFamily(family);
                AddFamily(people, familyMembers[0], familyMembers[1], familyMembers[2]);
            }

            return new ReadOnlyDictionary<string, IPerson>(people);
        }

        private static string[] SplitFamily(string family)
        {
            // Families are provided in the format child parentOne parentTwo
            return Parse.SplitList(family, " ");
        }

        private static void AddFamily(Dictionary<string, IPerson> people, string childName, string parentOneName, string parentTwoName)
        {
            IPerson parentOne = AddParent(people, parentOneName);
            IPerson parentTwo = AddParent(people, parentTwoName);
            AddChild(people, childName, parentOne, parentTwo);
        }

        private static IPerson AddParent(Dictionary<string, IPerson> people, string name)
        {
            if (!people.TryGetValue(name, out IPerson person))
            {
                person = new Person(name);
                people.Add(name, person);
            }

            return person;
        }

        private static IPerson AddChild(Dictionary<string, IPerson> people, string name, IPerson parentOne, IPerson parentTwo)
        {
            if (!people.TryGetValue(name, out IPerson person))
            {
                person = new Person(name, parentOne, parentTwo);
                people.Add(name, person);
            }
            else
            {
                Person child = (Person)person;
                child.ParentOne = parentOne;
                child.ParentTwo = parentTwo;
            }

            return person;
        }
    }
}