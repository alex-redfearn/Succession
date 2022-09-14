using System.Linq;

namespace Succession.Util
{
    public class Parse
    {
        public static int[] SplitNumericList(string list, string seperator)
        {
            return list.Split(" ")
                .Select(number => ParseInt(number))
                .ToArray();
        }

        public static string[] SplitList(string list, string seperator)
        {
            return list.Split(seperator);
        }

        private static int ParseInt(string number)
        {
            if(int.TryParse(number,out int output))
            {
                return output;
            } 
            else return 0;
        }
    }
}