using System;
using System.Linq;
using System.Collections.ObjectModel;
using Succession.Input;
using Succession.People;
using Succession.Util;

namespace Succession
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleInput input = new ConsoleInput();
            Country utopia = new Country(input);

            ReadOnlyDictionary<string, IPerson> population = utopia.Population;

            foreach(var item in population)
            {
                IPerson person = item.Value;
                string children = String.Join(",",person.Children.Select(child => child.Name));

                Console.WriteLine($"Name {person.Name}, Royal Blood {person.RoyalBlood}");
            }
            
        }
    }
}