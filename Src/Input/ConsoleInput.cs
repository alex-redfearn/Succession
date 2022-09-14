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

        public Founder GetFounder()
        {
            string name = _input[1];
            return new Founder(name);
        }

        public ReadOnlyDictionary<string, IPerson> GetPeople()
        {
            Dictionary<string, IPerson> people = new Dictionary<string, IPerson>();
            Founder founder = GetFounder();
            people.Add(founder.Name, founder);

            for(int i = 2; i <= _families + 1; i++)
            {
                string[] family = SplitFamily(_input[i]);

                string childName = family[0];
                string parentOneName = family[1];
                string parentTwoName = family[2];

                IPerson parentOne = GetOrCreatePerson(people, parentOneName);
                IPerson parentTwo = GetOrCreatePerson(people, parentTwoName);

                IPerson child = new Royal(childName, parentOne, parentTwo);
                people.Add(childName, child);
            }

            return new ReadOnlyDictionary<string, IPerson>(people);
        }

        private IPerson GetOrCreatePerson(Dictionary<string, IPerson> people, string name)
        {
            if (!people.TryGetValue(name, out IPerson person))
            {
                person = new Person(name);
                people.Add(name, person);
            }
            
            return person;
        }

        private string[] SplitFamily(string family)
        {
            return Parse.SplitList(family, " ");
        }

        private int[] GetCounts()
        {
            return Parse.SplitNumericList(_input[0], " ");
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
    }
}