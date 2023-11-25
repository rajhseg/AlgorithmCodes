using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class RomanConverter
    {
        static Dictionary<string, int> romanDict = new Dictionary<string, int>() {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };

        static Dictionary<int, string> intDict = new Dictionary<int, string>() {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        public static string FromInteger(int inputInteger)
        {
            string result = "";

            foreach (var item in intDict.OrderByDescending(x=>x.Key))
            {
                int value = item.Key;
                string symbol = item.Value;

                while (inputInteger >= value)
                {
                    result = result + symbol;
                    inputInteger = inputInteger - value;
                }
            }

            return result;
        }

        public static int ToInteger(string romanString)
        {
            int result = 0;
            int prev = 0;

            for (int i = romanString.Length -1; i >= 0; i--)
            {
                string letter = romanString[i].ToString();
                int value = romanDict[letter];

                if(value < prev)
                {
                    result = result - value;
                }
                else
                {
                    result = result + value;
                }

                prev = value;
            }

            return result;
        }
    }
}
