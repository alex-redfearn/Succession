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

        public ConsoleInput()
        {
            _input = ReadLines().AsReadOnly();
        }

        public Founder GetFounder()
        {
            string name = _input[1];
            return new Founder(name);
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