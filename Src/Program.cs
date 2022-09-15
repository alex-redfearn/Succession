using System;
using Succession.Input;
using Succession.People;
using Succession.Util;

namespace Succession
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPopulationInput input = new ConsoleInput();
            Country utopia = CreateCountry(input);

            string heir = utopia.GetHeir();
            Console.WriteLine(heir);
        }

        private static Country CreateCountry(IPopulationInput input)
        {
            Population population = new Population(input);
            return new Country(population);
        }
    }
}