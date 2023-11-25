using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public delegate void PrintFib(int number);
    
    public class Fibonacci
    {
        public static event PrintFib GeneratedFib;

        public static void PrintNumbers(int length)
        {
            int start = 0;
            int next = 1;
            int index = 1;

            GeneratedFib?.Invoke(next);

            do
            {
                int current = start + next;
                start = next;
                next = current;

                GeneratedFib?.Invoke(current);
                index++;
            }
            while(index < length);
        }
    }
}
