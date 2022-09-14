using System;
using Succession.Input;
using Succession.Util;

namespace Succession
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleInput input = new ConsoleInput();
            Country utopia = new Country(input);

            Console.WriteLine(utopia.Founder.Name);
            Console.WriteLine(utopia.Founder.RoyalBlood);
        }
    }
}