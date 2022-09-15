using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Succession.People;
using Succession.Util;

namespace Succession.Input
{
    public class ConsoleInput : IPopulationInput
    {
        private static readonly int FAMILY_START_LINE = 2;

        private readonly List<string> _input;
        private readonly int _familyCount;
        private readonly int _calimantCount;

        public ConsoleInput()
        {
            _input = ReadLines();
            
            int[] counts = GetCounts();
            _familyCount = counts[0];
            _calimantCount = counts[1];
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

        public string GetFounder()
        {
            // The founders name is on line 2 of the input.
            return _input[1];
        }

        public ReadOnlyCollection<string> GetFamilies()
        {
            return _input.GetRange(FAMILY_START_LINE, _familyCount).AsReadOnly();
        }

        public ReadOnlyCollection<string> GetClaimants()
        {
            int claimantStartLine = FAMILY_START_LINE + _familyCount;
            return _input.GetRange(claimantStartLine, _calimantCount).AsReadOnly();
        }
    }
}