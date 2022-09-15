using System.Collections.Generic;
using System.Collections.ObjectModel;
using Succession.Util;


namespace Succession.People
{
    public class Population
    {
        private readonly IPopulationInput _input;

        public Population(IPopulationInput input)
        {
            _input = input;
        }

        public ReadOnlyDictionary<string, IPerson> GetPeople()
        {
            Dictionary<string, IPerson> people = new Dictionary<string, IPerson>();
            
            Founder founder = new Founder(_input.GetFounder());
            people.Add(founder.Name, founder);

            // Lines 2 > family count contain the families in the format: child parentOne parentTwo
            foreach (string family in _input.GetFamilies())
            {
                string[] familyMembers = SplitFamily(family);
                AddFamily(people, familyMembers[0], familyMembers[1], familyMembers[2]);
            }

            return new ReadOnlyDictionary<string, IPerson>(people);
        }

        private string[] SplitFamily(string family)
        {
            return Parse.SplitList(family, " ");
        }

        private void AddFamily(Dictionary<string, IPerson> people, string childName, string parentOneName, string parentTwoName)
        {
            IPerson parentOne = GetOrCreateParent(people, parentOneName);
            IPerson parentTwo = GetOrCreateParent(people, parentTwoName);
            Royal child = (Royal)GetOrCreateChild(people, childName, parentOne, parentTwo);

            parentOne.Children.Add(child);
            parentTwo.Children.Add(child);

            child.SetRoyalBlood();

            if (child.Children.Count > 0)
            {
                // The list of famalies is not always in order.
                // If a parent is later found to be a child of royal descent,
                // we must recalculate their decscendants royal blood.
                UpdateDescendants(people, child);
            }
        }

        private IPerson GetOrCreateParent(Dictionary<string, IPerson> people, string name)
        {
            if (!people.TryGetValue(name, out IPerson person))
            {
                person = new Royal(name, new Common(), new Common());
                people.Add(name, person);
            }

            return person;
        }

        private IPerson GetOrCreateChild(Dictionary<string, IPerson> people, string name, IPerson parentOne, IPerson parentTwo)
        {
            if (!people.TryGetValue(name, out IPerson person))
            {
                person = new Royal(name, parentOne, parentTwo);
                people.Add(name, person);
            }
            else
            {
                Royal child = (Royal)person;
                child.ParentOne = parentOne;
                child.ParentTwo = parentTwo;
            }

            return person;
        }

        // Recursive. Will repeat until it reaches the last descendant.
        private void UpdateDescendants(Dictionary<string, IPerson> people, Royal person)
        {
            foreach (Royal child in person.Children)
            {
                child.SetRoyalBlood();
                UpdateDescendants(people, child);
            }
        }

        public ReadOnlyCollection<string> GetClaimants()
        {
            return _input.GetClaimants();
        }
    }
}