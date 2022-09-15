using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Succession.People;
using Succession.Util;

namespace Succession.Input
{
    public class ConsoleInput : ICountryInput
    {
        private readonly ReadOnlyCollection<string> _input;
        private readonly int _families;
        private readonly int _claimants;

        public ConsoleInput()
        {
            _input = ReadLines().AsReadOnly();

            int[] counts = GetCounts();
            _families = counts[0];
            _claimants = counts[1];
        }

        private List<string> ReadLines()
        {
            List<string> lines = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    break;
                }
                else
                {
                    lines.Add(input);
                }
            }

            return lines;
        }

        private int[] GetCounts()
        {
            // The first line in the input contains two integers separated by a space.
            // n1 count of families, n2 count of claimints.
            return Parse.SplitNumericList(_input[0], " ");
        }

        public Founder GetFounder()
        {
            // The founders name is on line 2 of the input.
            string name = _input[1];
            return new Founder(name);
        }

        public ReadOnlyDictionary<string, IPerson> GetPeople()
        {
            Dictionary<string, IPerson> people = new Dictionary<string, IPerson>();
            Founder founder = GetFounder();
            people.Add(founder.Name, founder);

            // Lines 2 > family count contain the families in the format: child parentOne parentTwo
            for (int i = 2; i <= _families + 1; i++)
            {
                string[] family = SplitFamily(_input[i]);
                AddFamily(people, family[0], family[1], family[2]);
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
            Royal child = (Royal) GetOrCreateChild(people, childName, parentOne, parentTwo);

            parentOne.Children.Add(child);
            parentTwo.Children.Add(child);

            child.SetRoyalBlood();
                
            if(child.Children.Count > 0)
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
                Royal child = (Royal) person;
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
    }
}