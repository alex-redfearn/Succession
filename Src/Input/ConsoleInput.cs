using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Internal;
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