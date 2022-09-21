using System;
using Succession.Input;

namespace Succession
{
    public class Program
    {
        public static void Main()
        {
            ICountryInput input = new ConsoleInput();
            Country utopia = new Country(input);

            string heir = utopia.GetHeir();
            Console.WriteLine(heir);
        }
    }
}